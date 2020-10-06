using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngASPNETCOREBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public string TelephoneNumber { get; set; }

        public Users()
        {

        }

        public Users(string username, string pass, string name)
        {
            Username = username;
            Password = pass;
            Name = name;
        }
    }
}
