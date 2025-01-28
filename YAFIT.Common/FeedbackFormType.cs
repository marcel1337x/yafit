using System.ComponentModel;

namespace YAFIT.Common
{
    public enum FeedbackFormType
    {
        [Description("Unbekannt")]
        Unknown = 0,
        [Description("Erstes Feedback")]
        First = 1,
        [Description("Kreisfeedback")]
        Second = 2
    }
}
