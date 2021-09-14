using authontecation.Authontecation;
using authontecation.helper;

using authontecation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace authontecation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthontecationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        //private readonly IMailService mailService;

        public AuthontecationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    name=user.UserName,
                    expiration = token.ValidTo
                });
            }
            if(user==null)
            return Ok(new response { Status="Error",Message="مستخدم غير مسجل"});
            else
                return Ok(new response { Status = "Error", Message = "كلمه المرور غير صحيحه" });
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var error = new List<string>();
                foreach (var item in result.Errors)
                {
                    error.Add(item.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Errors = error });
            }

            return Ok(new response { Status = "Success", Message = "User created successfully!" });
        }
        [HttpPost]
        [Route("forget")]
        public async Task<IActionResult> ForegetPassword(forgetPassword forgetPassword)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.FindByNameAsync(forgetPassword.UserName);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = forgetPassword.Email, Token = token }, Request.Scheme);

                    var data=Mail.SendMail("Reset Palssword Link", passwordResetLink, user.Email);
                    if (data == "send successfully")
                    {

                        return Ok(new response { Status = "Success", Message = token }) ;
                    }
                }
                return BadRequest(forgetPassword);
            }
            return BadRequest(forgetPassword);
        }


        [HttpPost]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetpassword)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetpassword.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, resetpassword.Token, resetpassword.Password);

                    if (result.Succeeded)
                    {
                        return Ok(new response { Status = "success",Message="password changed successfully"});
                    }

                    List<string> errors = new List<string>();
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }

                    return BadRequest(new { Status = "Error", Message = errors }) ;
                }

                return RedirectToAction("ConformResetPassword");
            }

            return BadRequest(new response { Message = "Invakid Data", Status = "Error" });
        }
        [HttpPost]
        [Route("IsTokenValid")]
        public IActionResult IsTokenValid(string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return Ok(new { Message="Invalid Token"});
            }
            return   Ok(new { Message = "valid Token" }); ;
        }
       /* [HttpPost("Logout")]
        public async Task<ActionResult> Logout()
        {
            
            return Ok();
        }*/



    }
    
}
