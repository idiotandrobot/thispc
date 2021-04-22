using System.Collections.ObjectModel;
using ThisPC.Properties;
using ThisPC.Services;

namespace ThisPC
{
    public class MainViewModel
    {
        const string DesktopKeyValue = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";

        const string Win8_1DownloadsKeyValue = "{374DE290-123F-4565-9164-39C4925E467B}";
        const string Win8_1DocumentsKeyValue = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
        const string Win8_1MusicKeyValue = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
        const string Win8_1PicturesKeyValue = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
        const string Win8_1VideosKeyValue = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";

        const string Win10DownloadsKeyValue = "{088e3905-0323-4b02-9826-5d99428e115f}";
        const string Win10DocumentsKeyValue = "{d3162b92-9365-467a-956b-92703aca08af}";
        const string Win10MusicKeyValue = "{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}";
        const string Win10PicturesKeyValue = "{24ad3ad4-a569-4530-98e1-ab02f9417aa8}";
        const string Win10VideosKeyValue = "{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}";
        const string Win10Objects3DKeyValue = "{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}";      

        public bool IsAdmin => OSService.IsAdmin;
        public string Title => OSService.IsAdmin ? Resources.AdministratorTitle : Resources.DefaultTitle;

        public ObservableCollection<FolderViewModel> Folders { get; } = new ObservableCollection<FolderViewModel>();
        
        public MainViewModel()
        {
            AddFolder(Resources.Desktop, DesktopKeyValue);
            AddFolder(Resources.Downloads, OSService.IsWin10 ? Win10DownloadsKeyValue : Win8_1DownloadsKeyValue);
            AddFolder(Resources.Documents, OSService.IsWin10 ? Win10DocumentsKeyValue : Win8_1DocumentsKeyValue);
            AddFolder(Resources.Music, OSService.IsWin10 ? Win10MusicKeyValue : Win8_1MusicKeyValue);
            AddFolder(Resources.Pictures, OSService.IsWin10 ? Win10PicturesKeyValue : Win8_1PicturesKeyValue);
            AddFolder(Resources.Videos, OSService.IsWin10 ? Win10VideosKeyValue : Win8_1VideosKeyValue);
            if (OSService.IsWin10) AddFolder(Resources.Objects3D, Win10Objects3DKeyValue);
        }

        private void AddFolder(string name, string key)
        {
            if (RegistryService.CLSIDExists(key)) Folders.Add(new FolderViewModel(name, key));
        }
    }
}
