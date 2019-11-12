using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ThisPC.Services;

namespace ThisPC
{
    public class FolderViewModel : INotifyPropertyChanged
    {
        List<FolderKey> FolderKeys = new List<FolderKey>();

        public FolderViewModel(string name, string key)
        {
            Name = name;
            foreach (var nameSpace in RegistryService.NameSpaceList)
            {
                FolderKeys.Add(new FolderKey(key, nameSpace));
            }
        }

        public string Name { get; private set; }
        
        public bool IsVisible
        {
            get { return FolderKeys.Count(fk => fk.Exists) > 0; }
            set { FolderKeys.ForEach(fk => fk.Exists = value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
