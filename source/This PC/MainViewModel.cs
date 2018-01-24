using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ThisPC.Properties;

namespace ThisPC
{
    public class MainViewModel
    {
        const string NameSpaceValue = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\";
        const string NameSpace32Value = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\";

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

        RootKey NameSpace = new RootKey(NameSpaceValue);
        RootKey NameSpace32 = new RootKey(NameSpace32Value);

        public ObservableCollection<FolderViewModel> Folders { get; private set; }

        public MainViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();

            Folders.Add(AddFolder(Resources.Desktop, new string[] { DesktopKeyValue, }));
            Folders.Add(AddFolder(Resources.Downloads, new string[] { DownloadsKeyValue, Win10DownloadsKeyValue, }));
            Folders.Add(AddFolder(Resources.Documents, new string[] { DocumentsKeyValue, Win10DocumentsKeyValue, }));
            Folders.Add(AddFolder(Resources.Music, new string[] { MusicKeyValue, Win10MusicKeyValue, }));
            Folders.Add(AddFolder(Resources.Pictures, new string[] { PicturesKeyValue, Win10PicturesKeyValue, }));
            Folders.Add(AddFolder(Resources.Videos, new string[] { VideosKeyValue, Win10VideosKeyValue, }));
            Folders.Add(AddFolder(Resources.Objects3D, new string[] { Win10Objects3DKeyValue, }));
        }

        private FolderViewModel AddFolder(string name, string[] keys)
        {
            return new FolderViewModel(name, keys, NameSpace, NameSpace32);
        }
    }
}
