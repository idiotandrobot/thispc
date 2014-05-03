using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ThisPC
{
    public class FolderKey
    {
        private RootKey RootKey;

        public string Key { get; private set; }

        public FolderKey(string key, RootKey rootKey)
        {
            RootKey = rootKey;
            Key = key;
        }

        public bool IsVisible
        {
            get
            {
                return RootKey.HasSubKey(Key);
            }
            set
            {
                if (value)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        public void Show()
        {
            if (!IsVisible)
            {
                RootKey.AddSubKey(Key);
            }
        }

        public void Hide()
        {
            if (IsVisible)
            {
                RootKey.RemoveSubKey(Key);
            }
        }
    }
}
