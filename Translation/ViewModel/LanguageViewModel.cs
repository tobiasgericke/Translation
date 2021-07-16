using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using TranslationWPF.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using LanguageLibrary;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TranslationWPF.ViewModel
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        //Testing Nuget
        private APIFunctions api = new APIFunctions();
        private List<string> texts = new List<string>();
        private string buttonText = "Hurr";
        //End Testing Nuget
        private ResourceManager rm;

        public LanguageViewModel()
        {
            LanguageSelectionViewModel = new LanguageSelectionViewModel(api);
            rm = ResourceManager.CreateFileBasedResourceManager("Strings","Strings", typeof(StringsResourceSet));
            ButtonText = api.Translate(ButtonText);
            PopulateTexts();
            //Texts = api.FetchTexts().GetString();
            ChangeTextTranslation("Hello", "HalliHallo", "English");
            api.LanguageChanged += ApiOnLanguageChanged;
        }

        public LanguageSelectionViewModel LanguageSelectionViewModel
        {
            get;
            set;
        }

        private void PopulateTexts()
        {
            //Resources.Strings.String1
            Texts.Add(api.FetchTexts().GetString("String1"));
            Texts.Add(api.FetchTexts().GetString("String2"));
            Texts.Add(api.FetchTexts().GetString("String3"));
        }

        private void ApiOnLanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            ButtonText = api.Translate(ButtonText);
            //Texts = api.FetchTexts();
        }

        public List<string> Texts
        {
            get { return texts; }
            set
            {
                texts = value;
                INotifyPropertyChanged("Texts");
            }
        }

        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                INotifyPropertyChanged("ButtonText");
            }
        }

        public void ChangeTextIntoSelectedLanguage()
        {
            //Texts = api.FetchTexts();
        }

        public void ChangeTextTranslation(string oldText, string newText, string language)
        {
            //api.ReplaceTranslations(oldText, newText, language);
        }

        // INotifyPropertyChanged Members 
        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public void SetDefaultCulture(CultureInfo culture)
        //{
        //    Type type = typeof(CultureInfo);
        //    try
        //    {
        //        type.InvokeMember("s_userDefaultCulture",
        //            BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
        //            null,
        //            culture,
        //            new object[] { culture });

        //        type.InvokeMember("s_userDefaultUICulture",
        //            BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
        //            null,
        //            culture,
        //            new object[] { culture });
        //    }
        //    catch { }

        //    try
        //    {
        //        type.InvokeMember("m_userDefaultCulture",
        //            BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
        //            null,
        //            culture,
        //            new object[] { culture });

        //        type.InvokeMember("m_userDefaultUICulture",
        //            BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
        //            null,
        //            culture,
        //            new object[] { culture });
        //    }
        //    catch { }
        //}
    }

    public class LanguageSelectionViewModel : INotifyPropertyChanged
    {
        //Testing Nuget
        private APIFunctions api;
        private string selectedLanguage;
        private List<string> languagesToImport = new List<string>();
        private List<string> importLanguages = new List<string>() { "English", "German", "Chinese" };
        

        public LanguageSelectionViewModel(APIFunctions api)
        {
            this.api = api;
            SelectedLanguage = api.StandardLanguage;
            LanguagesToImport = api.FetchLanguages(importLanguages);
        }

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                this.selectedLanguage = value;
                api.SetSelectedLanguage(SelectedLanguage);
                INotifyPropertyChanged("SelectedLanguage");
            }
        }

        public List<string> LanguagesToImport
        {
            get { return languagesToImport; }
            private set { languagesToImport = value; }
        }



        // INotifyPropertyChanged Members 
        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

