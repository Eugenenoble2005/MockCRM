using BC = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.IntegrationTests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace MockCRM.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }

        [Required,MinLength(5)]
        public string ?UserName { get; set; }

        [Required, MinLength(5,ErrorMessage ="Passoword is too short. Please have it be a minimum of 5 chars")]
        [JsonIgnore]
        public string ?Password { get; set; }
        public void HashPassword()
        {
            Password = BC.HashPassword(Password);
        }
        public bool Authenticate(ApplicationDbContext _context)
        {
            var requested_user = _context.User.Where(user => user.UserName == UserName);
            if(requested_user.Count() != 1)
            {
                return false;
            }
            if (BC.Verify(Password, requested_user.First().Password))
            {
                return true;   
            }
            return false;
        }
    }

}
