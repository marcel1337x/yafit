using System.ComponentModel;

namespace YAFIT.Common.Enums
{
    /// <summary>
    /// Ein Enum, das die verschiedenen Feedbackformulare definiert
    /// </summary>
    public enum FeedbackFormType
    {
        /// <summary>
        /// Unbekannt, wenn das Formular nicht bekannt ist
        /// </summary>
        [Description("Unbekannt")]
        Unknown = 0,
        /// <summary>
        /// Erstes Feedback Formular
        /// </summary>
        [Description("Erstes Feedback")]
        First = 1,
        /// <summary>
        /// Zweites Feedback Formular
        /// </summary>
        [Description("Kreisfeedback")]
        Second = 2,
        /// <summary>
        /// Drittes Feedback Formular
        /// </summary>
        [Description("Smileyback")]
        Third = 3
    }
}
