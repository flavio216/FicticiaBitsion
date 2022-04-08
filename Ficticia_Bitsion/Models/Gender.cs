using System;
using System.Collections.Generic;

#nullable disable

namespace Ficticia_Bitsion.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Clients = new HashSet<Client>();
        }

        public int GenId { get; set; }
        public string GenGender { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
