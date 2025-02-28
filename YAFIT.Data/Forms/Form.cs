using YAFIT.Common.Enums;
using YAFIT.Interfaces.Forms;

namespace YAFIT.Data.Forms
{
    /// <summary>
    /// Die Basisklasse eines Formulars
    /// </summary>
    public class Form : IForm
    {

        #region properties
        /// <summary>
        /// Die ID des Formulars
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// Der Zeitstempel des Formulars wann es erstellt wurde
        /// </summary>
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public string ID { get; }

        /// <summary>
        /// Der Typ des Formulars
        /// </summary>
        public FeedbackFormType FormType
        {
            get { return _formType; }
            set { _formType = value; }
        }

        #endregion

        #region member variables

        private string _code;
        private DateTime _timeStamp;
        private FeedbackFormType _formType;

        #endregion
    }
}
