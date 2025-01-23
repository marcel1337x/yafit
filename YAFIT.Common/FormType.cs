using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAFIT.Common
{
    public enum FormType
    {
        [Description("Unbekannt")]
        Unknown = 0,
        [Description("Erstes Feedback")]
        First = 1,
        [Description("Kreisfeedback")]
        Second = 2
    }
}
