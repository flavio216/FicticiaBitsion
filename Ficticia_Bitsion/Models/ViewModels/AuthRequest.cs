using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Models.ViewModels
{
    public class AuthRequest
    {
        [Required]
        public string UsrEmail { get; set; }
        [Required]
        public string UsrPassword { get; set; }
    }
}
