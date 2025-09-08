using Microsoft.AspNetCore.Mvc;

[Route("account")]
public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher _passwordHasher;

    public AccountController(ApplicationDbContext context, PasswordHasher hasher)
    {
        _context = context;
        _passwordHasher = hasher;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] string email, [FromForm] string password)
    {
        var hash = _passwordHasher.HashPassword(password);
        var hmac = HmacHelper.ComputeHmac(password, "my-secret-key");

        var user = new User
        {
            Email = email,
            PasswordHash = hash,
            Hmac = hmac
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered securely.");
    }
}
