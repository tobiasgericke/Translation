using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TranslationWPF.Model
{
    public class Language : INotifyPropertyChanged
    {
        private string languageName;

        public string LanguageName
        {
            get
            {
                return languageName;
            }
            set
            {
                languageName = value;
                OnPropertyChanged("LanguageName");
            }
        }

        // INotifyPropertyChanged Members 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
