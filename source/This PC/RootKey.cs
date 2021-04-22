using Microsoft.Win32;
using System;
using System.Security;

namespace ThisPC
{
    public class RootKey
    {
        private readonly RegistryKey ReadOnlyKey;

        public string Path { get; }

        public RootKey(string path)
        {
            Path = path;
            ReadOnlyKey = GetReadOnlyKey();
        }

        public bool HasSubKey(string key) => ReadOnlyKey.OpenSubKey(key) != null;

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

        private RegistryKey GetReadOnlyKey() => GetKey();

        private RegistryKey GetWriteableKey() => GetKey(true);

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
