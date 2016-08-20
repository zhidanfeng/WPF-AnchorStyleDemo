using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication4.ViewModel;

namespace WpfApplication4.Model
{
    public class AnchorInfo
    {
        private string displayTitle;

        public string DisplayTitle
        {
            get { return displayTitle; }
            set { displayTitle = value; }
        }
        private EnumPoliceNavigatePoint anchorName;

        public EnumPoliceNavigatePoint AnchorName
        {
            get { return anchorName; }
            set { anchorName = value; }
        }
    }
}
