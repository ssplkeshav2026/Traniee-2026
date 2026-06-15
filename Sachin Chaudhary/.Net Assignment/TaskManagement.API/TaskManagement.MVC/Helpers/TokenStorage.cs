using Microsoft.AspNetCore.Http;

public class TokenStorage
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TokenStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? AccessToken
    {
        get => _httpContextAccessor.HttpContext?.Session.GetString("JWT_Token");
        set => _httpContextAccessor.HttpContext?.Session.SetString("JWT_Token", value ?? "");
    }

    public string? RefreshToken
    {
        get => _httpContextAccessor.HttpContext?.Session.GetString("Refresh_Token");
        set => _httpContextAccessor.HttpContext?.Session.SetString("Refresh_Token", value ?? "");
    }

    public void Clear()
    {
        _httpContextAccessor.HttpContext?.Session.Clear();
    }
}