using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.Core.Model
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
    }
}
