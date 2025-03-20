using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using YAFIT.Databases.Attributes;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views.Forms.Formular1;
using YAFIT.Common.UI.ViewModel;
using YAFIT.UI.Views.Forms.Formular3;
using System.Diagnostics;

namespace YAFIT.UI.ViewModels.Forms.Formular3
{
    class ModelFormular3Result : BaseViewModel
    {




        public ModelFormular3Result(Window window, UmfrageEntity umfrage) : base(window)
        {
            _umfrage = umfrage;
            OnLoad();
        }
        #region private methods

        #region onload

        /// <summary>
        /// Wird aufgerufen, wenn das Fenster geladen wird
        /// </summary>
        private void OnLoad()
        {
            if (_view is ViewFormular3Result formular == false)
            {
                return;
            }

            //Aus der Datenbank laden
            IList<Formular3Entity> entities = Formular3Entity.GetFormular3Service().GetAllByCriteria(x => x.Umfrage_Id == _umfrage.Id);
            Debug.WriteLine("UMFRAGE: " + _umfrage.Id);



            //Textboxen

            foreach (Formular3Entity entity in entities)
            {
                Debug.WriteLine("TEST");
                formular.TextBoxQuestion1.Children.Add(new TextBlock() { Text = entity.Text0, TextWrapping = TextWrapping.Wrap });
                formular.TextBoxQuestion2.Children.Add(new TextBlock() { Text = entity.Text1, TextWrapping = TextWrapping.Wrap });
            }
            formular.UpdateLayout();

        }

        #endregion
        #endregion

        #region member variables

        private readonly UmfrageEntity _umfrage;




        #endregion
    }
}

