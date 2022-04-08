using System;
using System.Collections.Generic;

#nullable disable

namespace Ficticia_Bitsion.Models
{
    public partial class Client
    {
        public int CliId { get; set; }
        public string CliName { get; set; }
        public string CliDni { get; set; }
        public int CliDocDocumentType { get; set; }
        public int CliGenGender { get; set; }
        public bool CliActive { get; set; }
        public bool CliDrive { get; set; }
        public bool CliUseGlasses { get; set; }
        public bool CliDiabetic { get; set; }
        public bool CliOtherDiseases { get; set; }
        public string CliDiseases { get; set; }

        public virtual DocumentType CliDocDocumentTypeNavigation { get; set; }
        public virtual Gender CliGenGenderNavigation { get; set; }
    }
}
