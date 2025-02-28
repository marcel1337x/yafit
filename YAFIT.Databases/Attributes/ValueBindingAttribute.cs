namespace YAFIT.Databases.Attributes
{
    public class ValueBindingAttribute(int index) : Attribute
    {
        public int Index { get; private set; } =index;
    }
}
