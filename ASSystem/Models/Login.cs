﻿using System.ComponentModel.DataAnnotations;

namespace ASSystem.Models
{
    public class Login
    {

        [Required]
        [MaxLength(100)]
        public string username { get; set; }

        [Required]
        [MaxLength(100)]
        public string password { get; set; }
    }
}
