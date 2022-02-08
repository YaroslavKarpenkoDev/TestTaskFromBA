using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskFromBA.Models;
using TestTaskFromBA.Resources;

namespace TestTaskFromBA.ViewModels
{
	public class ImageInfoPageViewModel : ViewModelBase
	{
		public ImageInfoPageViewModel(INavigationService navigationService) : base(navigationService)
		{
		}
		#region Properties&Fields
		public string ImageUrl { get; set; }
		#endregion
		#region Lifecycle
		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			var info = parameters.GetValue<ImageResponseModel>("info");
			if (info != null)
			{
				ImageUrl = info.urls.small;
			}
		}
		#endregion

	}
}
