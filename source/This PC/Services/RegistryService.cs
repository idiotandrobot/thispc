namespace ThisPC.Services
{
    public class RegistryService
    {
        static readonly CLSIDKey CLSID = new CLSIDKey(@"CLSID\");
        static readonly CLSIDKey CLSID32 = new CLSIDKey(@"Wow6432Node\CLSID\");

        static readonly RootKey NameSpace = new RootKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\");
        static readonly RootKey NameSpace32 = new RootKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\");

        public static bool CLSIDExists(string key) => CLSID.HasSubKey(key) || CLSID32.HasSubKey(key);

        public static RootKey[] NameSpaceList => OSService.Is64Bit ? new RootKey[] { NameSpace, NameSpace32 } : new RootKey[] { NameSpace, };
    }
}
