using Prism;
using Prism.Ioc;
using TestTaskFromBA.Services;
using TestTaskFromBA.ViewModels;
using TestTaskFromBA.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TestTaskFromBA
{
	public partial class App
	{
		public App(IPlatformInitializer initializer)
			: base(initializer)
		{
		}

		protected override async void OnInitialized()
		{
			InitializeComponent();

			await NavigationService.NavigateAsync("NavigationPage/MainPage");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
			containerRegistry.RegisterSingleton<IRESTAPIService, RESTAPIService>();
			containerRegistry.RegisterSingleton<IStorageService, StorageService>();

			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
			containerRegistry.RegisterForNavigation<ImageInfoPage, ImageInfoPageViewModel>();
		}
	}
}
