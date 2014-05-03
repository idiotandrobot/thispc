using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThisPC
{
    [ImplementPropertyChanged]
    public class FolderViewModel
    {
        FolderKey FolderKey, FolderKey32;

        public FolderViewModel(string name, string key, RootKey nameSpace, RootKey nameSpace32)
        {
            Name = name;
            FolderKey = new FolderKey(key, nameSpace);
            FolderKey32 = new FolderKey(key, nameSpace32);
        }

        public string Name { get; private set; }
        
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
            }
        }
    }
}
