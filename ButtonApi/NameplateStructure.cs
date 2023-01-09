using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace HellsingCore.ButtonApi
{
    internal class NameplateStructure
    {
        public TextMeshProUGUI comp;
        private string userId;
        public TextMeshProUGUI component
        {
            get { return comp; }
            set { comp = value; }
        }

        public string ID
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
