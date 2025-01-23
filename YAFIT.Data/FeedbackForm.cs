using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAFIT.Common;

namespace YAFIT.Data
{
    public class FeedbackForm
    {
        public FormType Form { get; set; } = FormType.Unknown;

        public Guid? ID { get; set; } = null;
        
        public DateTime TimeStamp { get; set; } = DateTime.MinValue;
    }
}
