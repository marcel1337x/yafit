using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YAFIT.Data;
using YAFIT.UI.Resources;

namespace YAFIT.UI.ViewModels
{
    internal class checkBoxView : BaseViewModel
    {
        public List<FeedbackRow> FeedbackRows { get => _feedbackRows; set => _feedbackRows = value; }
        private List<FeedbackRow> _feedbackRows = new List<FeedbackRow>();


        public List<FeedbackRow> FeedbackRows1 { get => _feedbackRows1; set => _feedbackRows1 = value; }
        private List<FeedbackRow> _feedbackRows1 = new List<FeedbackRow>();
        public List<FeedbackRow> FeedbackRows2 { get => _feedbackRows2; set => _feedbackRows2 = value; }
        private List<FeedbackRow> _feedbackRows2 = new List<FeedbackRow>();

        public List<FeedbackRow2Text> FeedbackRows3 { get => _feedbackRows3; set => _feedbackRows3 = value; }
        private List<FeedbackRow2Text> _feedbackRows3 = new List<FeedbackRow2Text>();
        public checkBoxView(Window window) : base(window)
        {
            
            FeedbackRows.Add(new FeedbackRow { Text = "...bevorzugt manche Schülerinnen oder Schüler",CheckBox1=false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows.Add(new FeedbackRow { Text = "...nimmt die Schülerinnen oder Schüler ernst.",CheckBox1=false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false});
            FeedbackRows.Add(new FeedbackRow { Text = "...ermutigt und lobt viel", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows.Add(new FeedbackRow { Text = "...entscheidet immer allein", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows.Add(new FeedbackRow { Text = "...gesteht eigene Fehler ein.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });

            FeedbackRows1.Add(new FeedbackRow { Text = "Die Ziele des Unterrichts sind klar\r\nerkennbar.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Der Lehrer redet zu viel.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Der Lehrer schweift oft vom Thema ab.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Die Fragen und Beiträge der\r\nSchülerinnen und Schüler werden ernst\r\ngenommen.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Die Sprache des Lehrers ist gut\r\nverständlich.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Der Lehrer achtet auf Ruhe und Disziplin\r\nim Unterricht.", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Der Unterricht ist abwechslungsreich. ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Unterrichtsmaterialien sind ansprechend\r\nund gut verständlich gestaltet. ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows1.Add(new FeedbackRow { Text = "Der Stoff wird ausreichend wiederholt\r\nund geübt. ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });

            FeedbackRows2.Add(new FeedbackRow { Text = "Die Themen der Schulaufgaben werden\r\nrechtzeitig vorher bekannt gegeben. ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow { Text = "Der Schwierigkeitsgrad der\r\nLeistungsnachweise entspricht dem der\r\nUnterrichtsinhalte. ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow { Text = "Die Bewertungen sind nachvollziehbar\r\nund verständlich.  ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });

            FeedbackRows2.Add(new FeedbackRow2Text { Text = "Sie/Er ist ... ", Text2 = "... ungeduldig", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow2Text { Text = "", Text2 = "... sicher im Auftreten", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow2Text { Text = "", Text2 = "... freundlich", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow2Text { Text = "", Text2 = "... erregbar und\r\naufbrausend", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow2Text { Text = "", Text2 = "... tatkräftig, aktiv", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
            FeedbackRows2.Add(new FeedbackRow2Text { Text = "", Text2 = "... aufgeschlossen ", CheckBox1 = false, CheckBox2 = false, CheckBox3 = false, CheckBox4 = false });
        }
        
    }
}
