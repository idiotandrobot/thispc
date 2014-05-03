﻿using System;
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

        RootKey NameSpace = new RootKey(NameSpaceValue);
        RootKey NameSpace32 = new RootKey(NameSpace32Value);

        public ObservableCollection<FolderViewModel> Folders { get; private set; }

        public MainViewModel()
        {
            Folders = new ObservableCollection<FolderViewModel>();

            Folders.Add(AddFolder(Resources.Desktop, DesktopKeyValue));
            Folders.Add(AddFolder(Resources.Downloads, DownloadsKeyValue));
            Folders.Add(AddFolder(Resources.Documents, DocumentsKeyValue));
            Folders.Add(AddFolder(Resources.Music, MusicKeyValue));
            Folders.Add(AddFolder(Resources.Pictures, PicturesKeyValue));
            Folders.Add(AddFolder(Resources.Videos, VideosKeyValue));
        }

        private FolderViewModel AddFolder(string name, string key)
        {
            return new FolderViewModel(name, key, NameSpace, NameSpace32);
        }
    }
}
