using eKreta.Models;
using System;

namespace ASZAF.Models
{
    internal class User
    {
        public User()
        {
        }

        public User(string passwordHash, string role, string username, string fullname)
        {
            PasswordHash = passwordHash;
            Role = role;
            Username = username;
            Fullname = fullname;
        }

        public User(int id, string username, string email,string fullname, string passwordHash, string firstName, string lastName, DateTime createdAt, bool isActive, string role)
        {
            Id = id;
            Username = username;
            Email = email;
            Fullname = fullname;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = createdAt;
            IsActive = isActive;
            Role = role;
        }


        public int Id { get; set; }
        
        public string Email { get; set; }
      
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
      

        
        public string SzerepkorNev => Enum.GetName(typeof(Szerepkor), Role) ?? "Ismeretlen";
    }
}
    
