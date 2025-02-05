using YAFIT.Common.Enums;

namespace YAFIT.Interfaces.Forms
{

    /// <summary>
    /// Die Interface für ein Formular
    /// </summary>
    public interface IForm
    {

        #region properties
        /// <summary>
        /// Die ID des Formulars
        /// </summary>
        public Guid? ID { get; }

        /// <summary>
        /// Der Typ des Formulars
        /// </summary>
        public FeedbackFormType FormType { get; }

        /// <summary>
        /// Der Zeitstempel des Formulars wann es erstellt wurde
        /// </summary>
        public DateTime TimeStamp { get; }

        #endregion
    }
}
