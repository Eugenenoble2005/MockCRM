using Jose;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;
using System.Security.Cryptography;
using System.Text;

namespace MockCRM.Models { 
    public class JsonWebToken
    {
        private ApplicationDbContext _context;
        private IConfiguration _configuration;

        public string Create(User user)
        {
            int user_id = _context.User.Where(u=>u.UserName == user.UserName).First().Id;
            string appKey = _configuration["appKey"];
            Dictionary<string, dynamic> payload = new Dictionary<string, dynamic>()
            {
                {"Id",user_id},
                {"UserName",user?.UserName }
            };
            byte[] key = Encoding.ASCII.GetBytes(appKey);
            string token = Jose.JWT.Encode(payload,key,JwsAlgorithm.HS256);
            return token;
        }
       public string Verify(string token)
        {
            string appKey = _configuration["appKey"];
            byte[] key = Encoding.ASCII.GetBytes(appKey);
            string user = Jose.JWT.Decode(token, key, JwsAlgorithm.HS256);
            return user;
        }
        public JsonWebToken(ApplicationDbContext _context, IConfiguration _configuration)
        {
            this._context = _context;
            this._configuration = _configuration;
        }
    }
}
