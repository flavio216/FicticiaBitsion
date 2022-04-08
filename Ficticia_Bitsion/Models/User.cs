using System;
using System.Collections.Generic;

#nullable disable

namespace Ficticia_Bitsion.Models
{
    public partial class User
    {
        public int UsrId { get; set; }
        public string UsrEmail { get; set; }
        public string UsrPassword { get; set; }
        public string UsrNombre { get; set; }
    }
}
