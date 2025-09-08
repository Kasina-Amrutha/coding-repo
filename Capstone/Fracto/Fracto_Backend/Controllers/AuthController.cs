// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// //using FractoAPI.Models;
// using Backend.Models;

// namespace FractoAPI.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class AuthController : ControllerBase
//     {
//         private readonly FractoDbContext _context;
//         private readonly IConfiguration _config;

//         public AuthController(FractoDbContext context, IConfiguration config)
//         {
//             _context = context;
//             _config = config;
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login([FromBody] LoginDto dto)
//         {
//             var user = await _context.Users
//                 .FirstOrDefaultAsync(u => u.UserName == dto.Username && u.Password == dto.Password);

//             if (user == null)
//                 return Unauthorized("Invalid username or password");

//             var token = GenerateJwtToken(user);
//             return Ok(new { token, user });
//         }

//         private string GenerateJwtToken(User user)
//         {
//             var claims = new[]
//             {
//                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//                 new Claim("role", user.Role),
//                 new Claim("userId", user.UserId.ToString()),
//                 new Claim(ClaimTypes.Role, user.Role)
//             };

//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var token = new JwtSecurityToken(
//                 issuer: _config["Jwt:Issuer"],
//                 audience: _config["Jwt:Audience"],
//                 claims: claims,
//                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
//                 signingCredentials: creds);

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }
//     }

//     public class LoginDto
//     {
//         public string? Username { get; set; }
//         public string? Password { get; set; }
//     }
// }