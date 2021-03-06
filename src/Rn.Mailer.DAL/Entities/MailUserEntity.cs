﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rn.Mailer.DAL.Entities
{
    [Table("Users")]
    public class MailUserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Index]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime CreationDateUtc { get; set; }

        [Required]
        public DateTime LastLoginDateUtc { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string DisplayName { get; set; }
    }

}
