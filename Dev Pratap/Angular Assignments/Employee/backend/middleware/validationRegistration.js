
const validateRegistrationPayload = (req, res, next) => {
  const { email, password } = req.body;

  if (email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      return res.status(400).json({
        success: false,
        message: 'Invalid request: Provided email format structure is invalid.'
      });
    }
  }

  if (password && password.length < 6) {
    return res.status(400).json({
      success: false,
      message: 'Invalid request: Security parameters require passwords to be at least 6 characters long.'
    });
  }

  next();
};

module.exports = validateRegistrationPayload;