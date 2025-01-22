using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAFIT.Data
{
    public class FeedbackRow
    {
        string text;
        bool checkBox1 =false;
        bool checkBox2 = false;
        bool checkBox3 = false;
        bool checkBox4 = false;

        public string Text { get => text; set => text = value; }
        public bool CheckBox1 { get => checkBox1; set => checkBox1 = value; }
        public bool CheckBox2 { get => checkBox2; set => checkBox2 = value; }
        public bool CheckBox3 { get => checkBox3; set => checkBox3 = value; }
        public bool CheckBox4 { get => checkBox4; set => checkBox4 = value; }

    }
}
