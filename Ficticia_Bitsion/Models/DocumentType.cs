using System;
using System.Collections.Generic;

#nullable disable

namespace Ficticia_Bitsion.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Clients = new HashSet<Client>();
        }

        public int DocId { get; set; }
        public string DocDocument { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
