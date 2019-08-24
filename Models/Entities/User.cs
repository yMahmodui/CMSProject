using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        [Key] public int UserId { get; set; }

        public int RoleId { get; set; }

        [MaxLength(64)] public string Email { get; set; }

        public string Password { get; set; }

        public string RegisterDate { get; set; }

        [ForeignKey(nameof(RoleId))] public virtual Role Role { get; set; }
    }
}