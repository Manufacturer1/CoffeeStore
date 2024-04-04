using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class EditModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
       
        public string Email { get; set; }

       
    }
}