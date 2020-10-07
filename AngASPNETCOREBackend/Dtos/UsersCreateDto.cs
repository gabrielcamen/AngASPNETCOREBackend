using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Dtos
{
    public class UsersCreateDto
    { 
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
    }
}
