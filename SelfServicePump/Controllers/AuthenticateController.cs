using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SelfServicePump.Data.Autentication;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace SelfServicePump.Controllers
{
    public class AuthenticateController : ApiController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;


        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            this.roleManager = roleManager ??
                throw new ArgumentNullException(nameof(roleManager));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] LoginDTO model)
        {


            var user = await userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user.Email);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name as string, user.UserName as string),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole.ToString));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

    }

}
