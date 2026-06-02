using System;

namespace ASZAF.Models
{
    internal class User
    {
        public User()
        {
        }

        public User(int id, string username, string email, string passwordHash, string firstName, string lastName, DateTime createdAt, bool isActive, string role)
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = createdAt;
            IsActive = isActive;
            Role = role;
        }


        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
    }
}
