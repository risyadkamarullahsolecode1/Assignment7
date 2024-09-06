﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Domain.Email
{
    public class SmtpSettings
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}