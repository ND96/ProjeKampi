using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwt_core_proje_kampi.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            //var bytes = Encoding.UTF8.GetBytes("aspnetcoreprojekampi_for_testing_purposes_123");
            //SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            //SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            //JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience:"http://localhost",notBefore:DateTime.Now, expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
            //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //return handler.WriteToken(token);

            var bytes = Encoding.UTF8.GetBytes("aspnetcoreprojekampi_for_testing_purposes_123");
            var key = new SymmetricSecurityKey(bytes);

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256); // ✅ FIXED

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
