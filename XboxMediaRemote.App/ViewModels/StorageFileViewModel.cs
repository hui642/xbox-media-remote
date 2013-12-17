﻿using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml.Media.Imaging;
using PropertyChanged;

namespace XboxMediaRemote.App.ViewModels
{
    [ImplementPropertyChanged]
    public class StorageFileViewModel : StorageItemViewModel
    {
        private readonly StorageFile file;

        public StorageFileViewModel(StorageFile file)
            : base(file)
        {
            this.file = file;
        }

        public StorageFile File
        {
            get
            {
                return file;
            }
        }

        public BitmapImage ThumbnailImage
        {
            get;
            set;
        }

        public bool HasThumbnailImage
        {
            get
            {
                return ThumbnailImage != null;
            }
        }

        public async Task LoadThumbnailAsync()
        {
            using (var thumbnail = await File.GetThumbnailAsync(ThumbnailMode.ListView, 150, ThumbnailOptions.UseCurrentScale))
            {
                if (thumbnail == null)
                    return;

                ThumbnailImage = new BitmapImage();
                ThumbnailImage.SetSource(thumbnail);
            }
        }
    }
}
