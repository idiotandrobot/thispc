using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThisPC.Properties;

namespace ThisPC
{
    public class MainViewModel
    {
        const string NameSpaceValue = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\";
        const string NameSpace32Value = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\";

        const string DesktopKeyValue = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
        const string DownloadsKeyValue = "{374DE290-123F-4565-9164-39C4925E467B}";
        const string DocumentsKeyValue = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
        const string MusicKeyValue = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
        const string PicturesKeyValue = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
        const string VideosKeyValue = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";

        const string Win10DownloadsKeyValue = "{088e3905-0323-4b02-9826-5d99428e115f}";
        const string Win10DocumentsKeyValue = "{d3162b92-9365-467a-956b-92703aca08af}";
        const string Win10MusicKeyValue = "{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}";
        const string Win10PicturesKeyValue = "{24ad3ad4-a569-4530-98e1-ab02f9417aa8}";
        const string Win10VideosKeyValue = "{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}";
        const string Win10Objects3DKeyValue = "{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}";

        string[] DesktopKeys = new string[] { DesktopKeyValue, };
        string[] DownloadsKeys = new string[] { DownloadsKeyValue, Win10DownloadsKeyValue, };
        string[] DocumentsKeys = new string[] { DocumentsKeyValue, Win10DocumentsKeyValue, };
        string[] MusicKeys = new string[] { MusicKeyValue, Win10MusicKeyValue, };
        string[] PicturesKeys = new string[] { PicturesKeyValue, Win10PicturesKeyValue, };
        string[] VideosKeys = new string[] { VideosKeyValue, Win10VideosKeyValue, };
        string[] Objects3DKeys = new string[] { Win10Objects3DKeyValue, };

        RootKey NameSpace = new RootKey(NameSpaceValue);
        RootKey NameSpace32 = new RootKey(NameSpace32Value);

        CLSIDKey CLSID = new CLSIDKey(@"CLSID\");
        CLSIDKey CLSID32 = new CLSIDKey(@"Wow6432Node\CLSID\");

        public bool IsAdmin { get; private set; } 
        public string Title { get; private set; } 
        public ObservableCollection<FolderViewModel> Folders { get; private set; } = new ObservableCollection<FolderViewModel>();


        public MainViewModel()
        {
            IsAdmin = HasAdministratorPrivileges();
            Title = IsAdmin ? Resources.AdministratorTitle : Resources.DefaultTitle;

            AddFolder(Resources.Desktop, DesktopKeys);
            AddFolder(Resources.Downloads, DownloadsKeys);
            AddFolder(Resources.Documents, DocumentsKeys);
            AddFolder(Resources.Music, MusicKeys);
            AddFolder(Resources.Pictures, PicturesKeys);
            AddFolder(Resources.Videos, VideosKeys);
            AddFolder(Resources.Objects3D, Objects3DKeys);
        }

        private void AddFolder(string name, string[] keys)
        {
            if (CLSIDsExist(keys)) Folders.Add(CreateFolder(name, keys));
        }

        private bool CLSIDsExist(string[] names)
        {
            foreach (var name in names)
                if (CLSIDExists(name)) return true;

            return false;
        }

        private bool CLSIDExists(string name)
        {
            return CLSID.HasSubKey(name) || CLSID32.HasSubKey(name);
        }

        private FolderViewModel CreateFolder(string name, string[] keys)
        {
            return new FolderViewModel(name, keys, NameSpace, NameSpace32);
        }

        private static bool HasAdministratorPrivileges()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
