using Microsoft.AspNetCore.Mvc;
using apidemo.Data.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apidemo.DTOs;
using apidemo.Data.Repository.Interfaces;

//acá hacemos el token 

namespace apidemo.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(UserRepository userRepository, IConfiguration config)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            this._userRepository = userRepository;
        }

        public ActionResult Authenticate(AuthenticationRequestBody requetestBody)
        {
           {
                var user = _userRepository.ValidarUsuario(requetestBody);
                if (user != null)
                {
                    var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                    var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                    //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                    var claimsForToken = new List<Claim>();
                    claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                    claimsForToken.Add(new Claim("given_name", user.Name)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
                    claimsForToken.Add(new Claim("family_name", user.LastName)); //quiere usar la API por lo general lo que espera es que se estén usando estas keys.
                    claimsForToken.Add(new Claim("role", user.Rol.ToString())); //vinculado al ContactController método delete

                    var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                      _config["Authentication:Issuer"],
                      _config["Authentication:Audience"],
                      claimsForToken,
                      DateTime.UtcNow,
                      DateTime.UtcNow.AddHours(1),
                      credentials);

                    var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                        .WriteToken(jwtSecurityToken);

                    return Ok(tokenToReturn);
                }
                else
                {
                    return Unauthorized();
                }
            }

        }
                
                
    }
}
