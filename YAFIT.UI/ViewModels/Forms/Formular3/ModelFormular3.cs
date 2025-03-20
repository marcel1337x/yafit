﻿using System.Windows;
using System.Windows.Input;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Entities;

namespace YAFIT.UI.ViewModels.Forms.Formular3
{
    internal class ModelFormular3 : BaseViewModel
    {
        public ICommand OnSendResults { get; private set; }
        public string[] TextBoxQuestion
        {
            get { return _textBoxQuestions; }
            set { SetProperty(nameof(TextBoxQuestion), ref _textBoxQuestions, value); }
        }

        public ModelFormular3(Window window, UmfrageEntity umfrage) : base(window)
        {
            _umfrage = umfrage;
            OnSendResults = new RelayCommand(DoSendResults);
        }

        private void DoSendResults()
        {

            
            Formular3Entity form = new Formular3Entity();

           
            // Textfelder hinzufügen
            form.Text0 = TextBoxQuestion[0];
            form.Text1 = TextBoxQuestion[1];

            form.Umfrage_Id = _umfrage.Id;

            // Speichern in der Datenbank
            Formular3Entity.GetFormular3Service().Insert(form);

            
            CloseView();
        }


        private string[] _textBoxQuestions = [string.Empty, string.Empty, string.Empty];
        private readonly UmfrageEntity _umfrage;
    }
}
