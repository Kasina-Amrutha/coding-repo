using Microsoft.AspNetCore.Identity;

public class PasswordHasher
{
    public string HashPassword(string password)
    {
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
        return hasher.HashPassword(null, password);
    }

    public bool VerifyPassword(string hash, string password)
    {
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<string>();
        var result = hasher.VerifyHashedPassword(null, hash, password);
        return result == PasswordVerificationResult.Success;
    }
}
