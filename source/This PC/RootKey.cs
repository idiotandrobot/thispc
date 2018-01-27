using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ThisPC
{
    public class RootKey
    {
        private RegistryKey ReadOnlyKey;

        public string Path { get; private set; }

        public RootKey(string path)
        {
            Path = path;
            ReadOnlyKey = GetReadOnlyKey();
        }

        public bool HasSubKey(string key)
        {
            return ReadOnlyKey.OpenSubKey(key) != null;
        }

        public void AddSubKey(string key)
        {
            try
            {
                using (var writeableKey = GetWriteableKey())
                {
                    writeableKey.CreateSubKey(key);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        public void RemoveSubKey(string key)
        {
            try
            {
                using (var writeableKey = GetWriteableKey())
                {
                    writeableKey.DeleteSubKey(key);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        private RegistryKey GetReadOnlyKey()
        {
            return GetKey();
        }

        private RegistryKey GetWriteableKey()
        {
            return GetKey(true);
        }

        private RegistryKey GetKey(bool writable = false)
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey(Path, writable);
            }
            catch (SecurityException)
            {
                return GetKey();
            }
        }
    }
}
