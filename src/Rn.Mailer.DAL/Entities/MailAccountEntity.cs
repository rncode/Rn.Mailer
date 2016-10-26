﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rn.Mailer.DAL.Entities
{
    [Table("MailAccounts")]
    public class MailAccountEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Index]
        public int Id { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime DateAddedUtc { get; set; }

        [Required]
        public long MailsSent { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [Required]
        public string Host { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public bool UseSsl { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string FromName { get; set; }
    }
}