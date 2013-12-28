using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This_PC
{
    public class FolderKey
    {
        public static RegistryKey NameSpaceKey = ReadOnlyNameSpaceKey();

        public string Key { get; private set; }

        public FolderKey(string key)
        {
            Key = key;
        }

        public bool IsVisible
        {
            get
            {
                return NameSpaceKey.GetSubKeyNames().Contains(Key);
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
                using (var nameSpaceKey = WriteableNameSpaceKey())
                {
                    nameSpaceKey.CreateSubKey(Key);
                }
            }
        }

        public void Hide()
        {
            if (IsVisible)
            {
                using (var nameSpaceKey = WriteableNameSpaceKey())
                {
                    nameSpaceKey.DeleteSubKey(Key);
                }               
            }
        }

        private static RegistryKey ReadOnlyNameSpaceKey()
        {
            return GetNameSpaceKey();
        }

        private static RegistryKey WriteableNameSpaceKey()
        {
            return GetNameSpaceKey(true);
        }

        private static RegistryKey GetNameSpaceKey(bool writable = false)
        {
            return Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\", writable);
        }
    }
}
