using System;
using System.Collections.Generic;
using System.Text;
using TestTaskFromBA.Models;
using Xamarin.Essentials;

namespace TestTaskFromBA.AuxiliaryAdditions
{
	public static class AppData
	{
        private const string FirstStartKey = "firstStart";
        private static readonly bool FirstStartDefault = true;
        public static bool FirstStart
        {
            get => Preferences.Get(FirstStartKey, FirstStartDefault);
            set => Preferences.Set(FirstStartKey, value);
        }

        private const string ImagesListKey = "imagesList";
        private static readonly string ImagesListDefault = "";
        public static string ImagesList
        {
            get => Preferences.Get(ImagesListKey, ImagesListDefault);
            set => Preferences.Set(ImagesListKey, value);
        }
    }
}
