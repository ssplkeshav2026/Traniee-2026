using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.CustomAttributes;
using RoleBasedAuth.Data;
using RoleBasedAuth.Models;
using RoleBasedAuth.Models.ViewModel;
using System.Diagnostics;

namespace RoleBasedAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [Auth]

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string fileName = "";

                    if (model.ImageFile != null)
                    {
                        string uploadFolderImg = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                        string filePath = Path.Combine(uploadFolderImg, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                           await model.ImageFile.CopyToAsync(stream);
                        }
                    }

                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Name = model.Name,
                        Age = model.Age,
                        Status = true,
                        ImagePath = fileName
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        if (model.Email == "admin@admin.com" && model.Password == "Admin@123")
                        {
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }
                        return RedirectToAction("Login");
                    }
                }

                return View(model);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (!checkPassword)
                    {
                        ModelState.AddModelError("", "Invalid Password");
                        return View();
                    }

                    if (user.Status == false)
                    {
                        ModelState.AddModelError("", "Your account is inactive");
                        return View();

                    }
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);


                    if (result.Succeeded)
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                }
                ModelState.AddModelError("", "Invalid email and password");

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        if (model.NewPassword != model.ConfirmPassword)
                        {
                            ModelState.AddModelError("", "New Password and Confirm Password must be same");

                            return View("ChangePassword");


                        }
                        var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }

                    }

                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }

        [Authorize]
        public async Task<IActionResult> ManageProfile()
        {

            var user = await _userManager.GetUserAsync(User);
            var model = new ProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                ImagePath = user.ImagePath
            };
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> EditUserProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new EditUserProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                ExistingImage = user.ImagePath
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Name = model.Name;
            user.Age = model.Age;
            user.Email = model.Email;
            if(model.ImageFile != null)
            {

                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    string oldImagePath = Path.Combine( _webHostEnvironment.WebRootPath, "images",  user.ImagePath);

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                string fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;

                string filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                user.ImagePath = fileName;
            }
            await _userManager.UpdateAsync(user);

            return RedirectToAction("ManageProfile");
        }
    }
    }


