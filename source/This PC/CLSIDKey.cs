using Microsoft.Win32;
using System.Security;

namespace ThisPC
{
    public class CLSIDKey
    {
        private RegistryKey ReadOnlyKey;

        public string Path { get; private set; }

        public CLSIDKey(string path)
        {
            Path = path;
            ReadOnlyKey = GetReadOnlyKey();
        }

        public bool HasSubKey(string key)
        {
            return ReadOnlyKey.OpenSubKey(key) != null;
        }

        private RegistryKey GetReadOnlyKey()
        {
            return GetKey();
        }

        private RegistryKey GetKey(bool writable = false)
        {
            try
            {
                return Registry.ClassesRoot.OpenSubKey(Path, writable);
            }
            catch (SecurityException)
            {
                return GetKey();
            }
        }
    }
}
