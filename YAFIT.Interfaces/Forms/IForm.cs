using YAFIT.Common;

namespace YAFIT.Interfaces.Forms
{
    public interface IForm
    {
        public Guid? ID { get; }

        public FeedbackFormType FormType { get; }

        public DateTime TimeStamp { get; }

    }
}
