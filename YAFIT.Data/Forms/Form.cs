using YAFIT.Common;
using YAFIT.Interfaces.Forms;

namespace YAFIT.Data.Forms
{
    public class Form : IForm
    {
        public Guid? ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public FeedbackFormType FormType
        {
            get { return _formType; }
            set { _formType = value; }
        }

        private Guid? _id;
        private DateTime _timeStamp;
        private FeedbackFormType _formType;
    }
}
