using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThisPC
{
    public class FolderViewModel : INotifyPropertyChanged
    {
        FolderKey FolderKey, FolderKey32;

        public FolderViewModel(string name, string key, RootKey nameSpace, RootKey nameSpace32)
        {
            Name = name;
            FolderKey = new FolderKey(key, nameSpace);
            FolderKey32 = new FolderKey(key, nameSpace32);
        }

        private string name;
        public string Name 
        {
            get { return name; } 
            private set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        
        public bool IsVisible
        {
            get 
            {
                return FolderKey.IsVisible
                    || FolderKey32.IsVisible;
            }
            set
            {
                FolderKey.IsVisible = value;
                FolderKey32.IsVisible = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
