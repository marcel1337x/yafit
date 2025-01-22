using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YAFIT.Data
{
    public class FeedbackRow2Text : FeedbackRow
    {
        string text2;
        public string Text2 { get => text2; set => text2 = value; }
    }
}
