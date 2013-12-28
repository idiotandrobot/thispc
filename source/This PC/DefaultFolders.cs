using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This_PC
{
    public class DefaultFolders : INotifyPropertyChanged
    {
        FolderKey DesktopKey = new FolderKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
        FolderKey DownloadsKey = new FolderKey("{374DE290-123F-4565-9164-39C4925E467B}");
        FolderKey DocumentsKey = new FolderKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
        FolderKey MusicKey = new FolderKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
        FolderKey PicturesKey = new FolderKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
        FolderKey VideosKey = new FolderKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
        
        public bool Desktop
        {
            get { return DesktopKey.IsVisible; }
            set
            {
                DesktopKey.IsVisible = value;
                NotifyPropertyChanged("Desktop");
            }
        }

        public bool Downloads
        {
            get { return DownloadsKey.IsVisible; }
            set
            {
                DownloadsKey.IsVisible = value;
                NotifyPropertyChanged("Downloads");
            }
        }

        public bool Documents 
        {
            get { return DocumentsKey.IsVisible; }
            set
            {
                DocumentsKey.IsVisible = value;
                NotifyPropertyChanged("Documents");
            } 
        }

        public bool Music 
        {
            get { return MusicKey.IsVisible; }
            set
            {
                MusicKey.IsVisible = value;
                NotifyPropertyChanged("Music");
            }
        }

        public bool Pictures
        {
            get { return PicturesKey.IsVisible; }
            set
            {
                PicturesKey.IsVisible = value;
                NotifyPropertyChanged("Pictures");
            }
        }

        public bool Videos
        {
            get { return VideosKey.IsVisible; }
            set
            {
                VideosKey.IsVisible = value;
                NotifyPropertyChanged("Videos");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
