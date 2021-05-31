using Seeing_I_Go_toy_project.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Seeing_I_Go_toy_project.Helpers
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        public static LocalizationResourceManager Instance { get; } = new LocalizationResourceManager();
        public string this[string text]
        {
            get
            {
                return AppResources.ResourceManager.GetString(text, AppResources.Culture);
            }
        }
        public void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;
            Invalidate();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
