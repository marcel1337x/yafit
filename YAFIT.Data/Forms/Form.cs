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
        public Guid? ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Der Zeitstempel des Formulars wann es erstellt wurde
        /// </summary>
        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

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

        private Guid? _id;
        private DateTime _timeStamp;
        private FeedbackFormType _formType;

        #endregion
    }
}
