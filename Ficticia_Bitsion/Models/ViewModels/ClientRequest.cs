using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Models.ViewModels
{
    public class ClientRequest
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
    }
}
