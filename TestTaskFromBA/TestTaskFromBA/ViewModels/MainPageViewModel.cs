using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TestTaskFromBA.AuxiliaryAdditions;
using TestTaskFromBA.Models;
using TestTaskFromBA.Views;
using Xamarin.Forms;

namespace TestTaskFromBA.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		public MainPageViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			ResponseModel = new List<ImageResponseModel>();
		}

		#region Properties&Fields
		public bool IsButtonActive { get; set; }
		public bool IsRefreshing { get; set; }
		public List<ImageResponseModel> ResponseModel { get; set; }

		private ImageResponseModel selectedImage;
		public ImageResponseModel SelectedImage
		{
			get
			{
				return selectedImage;
			}
			set
			{
				if(selectedImage != value)
				{
					selectedImage = value;
				}
				if (value != null)
				{
					NavigateToInfoPage();
				}				
			}
		}
		#endregion

		#region Commands
		public ICommand ClearSavedDataCommand => new Command(ClearSavedData);
		public ICommand RefreshCommand => new Command(Refresh);
		#endregion

		#region Lifecycle
		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			if (SelectedImage != null)
			{
				SelectedImage = null;
			}			
			LoadData();
		}
		#endregion

		#region Methods
		public async void LoadData()
		{
			try
			{
				if (AppData.FirstStart || string.IsNullOrWhiteSpace(AppData.ImagesList))
				{
					var response = await Rest.GetRequest(ResponseModel, Endpoints.GetRandomImage);
					if (response != null)
					{
						AppData.ImagesList = Storage.SavingData(response);
					}
					ResponseModel = Storage.GetDataFromStorage<List<ImageResponseModel>>(AppData.ImagesList);
					AppData.FirstStart = false;
					IsButtonActive = true;
				}
				else if (ResponseModel.Count() == 0)
				{
					ResponseModel = Storage.GetDataFromStorage<List<ImageResponseModel>>(AppData.ImagesList);
					IsButtonActive = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async void NavigateToInfoPage()
		{
			var navigationParameters = new NavigationParameters()
			{
				{"info", SelectedImage }
			};
			await NavigationService.NavigateAsync($"{nameof(ImageInfoPage)}", navigationParameters);			
		}

		public void Refresh()
		{

			IsRefreshing = true;
			LoadData();
			IsRefreshing = false;
		}

		public void ClearSavedData()
		{
			ResponseModel = new List<ImageResponseModel>();
			AppData.ImagesList = string.Empty;
			IsButtonActive = false;			
		}
		#endregion
	}
}
