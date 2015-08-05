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
        List<FolderKey> FolderKeys = new List<FolderKey>();

        public FolderViewModel(string name, string[] keys, RootKey nameSpace, RootKey nameSpace32)
        {
            Name = name;
            foreach (var key in keys)
            {
                FolderKeys.Add(new FolderKey(key, nameSpace));
                FolderKeys.Add(new FolderKey(key, nameSpace32));
            }
        }

        public string Name { get; private set; }
        
        public bool IsVisible
        {
            get { return FolderKeys.Count(fk => fk.Exists) > 0; }
            set { FolderKeys.ForEach(fk => fk.Exists = value); }
        }
    }
}
