namespace ThisPC.Services
{
    public class RegistryService
    {
        static CLSIDKey CLSID = new CLSIDKey(@"CLSID\");
        static CLSIDKey CLSID32 = new CLSIDKey(@"Wow6432Node\CLSID\");

        static RootKey NameSpace = new RootKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\");
        static RootKey NameSpace32 = new RootKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\");

        public static bool CLSIDExists(string key)
        {
            return CLSID.HasSubKey(key) || CLSID32.HasSubKey(key);
        }

        public static RootKey[] NameSpaceList { get; private set; } = OSService.Is64Bit ? new RootKey[] { NameSpace, NameSpace32 } : new RootKey[] { NameSpace, };
    }
}
