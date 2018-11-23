using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User:EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public int MyProperty { get; set; }
    }
}
