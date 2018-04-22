using Microsoft.AspNetCore.Identity;
using System;

namespace WebsiteWithLogin.Models
{
    public class StudentUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}