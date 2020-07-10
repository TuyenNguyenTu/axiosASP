using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_api.Models
{
    public class Account
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime CreatDate { set; get; }
        public bool RememberMe { get; set; }
    }
}
