using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveMeName.Models
{
    public class UserListVM
    {
        public string UrlAddress { get; set; }
        public List<User> Users { get; set; }

        public UserListVM()
        {
            this.Users = new List<User>();
        }
    }
}