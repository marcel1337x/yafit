﻿using FluentNHibernate.MappingModel.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using YAFIT.Common.UI.ViewModel;
using YAFIT.Databases.Attributes;
using YAFIT.Databases.Entities;
using YAFIT.UI.UserControls;
using YAFIT.UI.Views.Forms.Formular1;

namespace YAFIT.UI.ViewModels.Forms.Formular1
{
    public class WindowFormFormular1ResultModel : BaseViewModel
    {
        public WindowFormFormular1ResultModel(Window window, UmfrageEntity umfrage) : base(window)
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
            if (_view is Formular1Result formular == false)
            {
                return;
            }

            //FieldInfo? field = formType.GetType().GetField(formType.ToString());
            //if (field != null)
            //{
            //    DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            //    return attribute?.Description ?? DEFAULT_VALUE;
            //}

            //Aus der Datenbank laden
            IList<Formular1Entity> entities = Formular1Entity.GetFormular1Service()
                .GetAllByCriteria(x => x.Umfrage.Id == _umfrage.Id);
            Type type = typeof(Formular1Entity);
            int[][] results = [.. Enumerable.Range(0, _presetGroup1.Length + _presetGroup2.Length + _presetGroup3.Length + _presetGroup4.Length+1)
                .Select(x => new int[] { 0, 0, 0, 0, 0 })];
            foreach (Formular1Entity entity in entities)
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    ValueBindingAttribute? attribute = property.GetCustomAttribute<ValueBindingAttribute>();
                    if (attribute == null)
                    {
                        continue;
                    }
                    object? value = property.GetValue(entity);
                    if (value == null)
                    {
                        continue;
                    }

                    if (value is int intValue)
                    {
                        int index = attribute.Index;
                        results[index][intValue] += 1;
                    }
                }
            }
            //Fragen Gruppe 1
            {
                StackPanel stackPanel = formular.EntryGroup1;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup1.Length; i++)
                {
                    int[] result = results[i];

                    FormEntryIntCheckboxDouble formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup1[i][0],
                        Text2 = _presetGroup1[i][1],
                        Results = result

                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            //Fragen Gruppe 2
            {
                StackPanel stackPanel = formular.EntryGroup2;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup2.Length; i++)
                {
                    int[] result = results[_presetGroup1.Length + i];
                    FormEntryIntCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup2[i],
                        Results = result
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }

            //Fragen Gruppe 3
            {
                StackPanel stackPanel = formular.EntryGroup3;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup3.Length; i++)
                {
                    int[] result = results[_presetGroup1.Length + _presetGroup2.Length + i];
                    FormEntryIntCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup3[i],
                        Results = result
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            //Fragen Gruppe 4
            {
                StackPanel stackPanel = formular.EntryGroup4;
                stackPanel.Children.Clear();
                for (int i = 0; i < _presetGroup4.Length; i++)
                {
                    int[] result = results[_presetGroup1.Length + _presetGroup2.Length + _presetGroup3.Length + i];
                    FormEntryIntCheckboxSingle formEntryTextCheckBox = new()
                    {
                        Text1 = _presetGroup4[i],
                        Results = result
                    };
                    stackPanel.Children.Add(formEntryTextCheckBox);
                }
            }
            formular.UpdateLayout();
        }

        #endregion
        #endregion

        #region member variables

        private readonly UmfrageEntity _umfrage;
        private string[] _textBoxQuestions = [string.Empty, string.Empty, string.Empty];


        private static readonly string[][] _presetGroup1 = [
            ["Sie/Er ist...", "...ungeduldig"],
            ["","...sicher im Auftreten"],
            ["","...freundlich"],
            ["","...erregbar und aufbrausend"],
            ["","...tatkräftig, aktiv"],
            ["","...aufgeschlossen"]
        ];
        private static readonly string[] _presetGroup2 = [
            "... bevorzugt manche Schülerinnen oder Schüler.",
            "...nimmt die Schülerinnen und Schüler ernst.",
            "...ermutigt und lobt viel.",
            "...entscheidet immer allein. ",
            "...gesteht eigene Fehler ein."
        ];
        private static readonly string[] _presetGroup3 = [
            "Die Ziele des Unterrichts sind klar erkennbar.",
            "Der Lehrer redet zu viel.",
            "Der Lehrer schweift oft vom Thema ab.",
            "Die Fragen und Beiträge der Schülerinnen und Schüler werden ernstgenommen.",
            "Die Sprache des Lehrers ist gutverständlich.",
            "Der Lehrer achtet auf Ruhe und Disziplin im Unterricht.",
            "Der Unterricht ist abwechslungsreich.",
            "Unterrichtsmaterialien sind ansprechend und gut verständlich gestaltet.",
            "Der Stoff wird ausreichend wiederholt und geübt."
        ];

        private static readonly string[] _presetGroup4 = [
            "Die Themen der Schulaufgaben werden rechtzeitig vorher bekannt gegeben.",
            "Der Schwierigkeitsgrad der Leistungsnachweise entspricht dem der Unterrichtsinhalte.",
            "Die Bewertungen sind nachvollziehbar und verständlich."
        ];


        #endregion
    }
}
