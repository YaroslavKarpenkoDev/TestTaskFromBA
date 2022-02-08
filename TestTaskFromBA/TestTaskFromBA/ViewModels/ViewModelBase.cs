using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskFromBA.Services;

namespace TestTaskFromBA.ViewModels
{
	public abstract class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
	{
		protected INavigationService NavigationService { get; private set; }

		protected IRESTAPIService Rest { get; private set; }

		protected IStorageService Storage { get; private set; }

		public ViewModelBase(INavigationService navigationService)
		{
			NavigationService = navigationService;
		}
		public ViewModelBase(INavigationService navigationService, IRESTAPIService restService, IStorageService storageService)
		{
			NavigationService = navigationService;
			Rest = restService;
			Storage = storageService;
		}
		public virtual void Initialize(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(INavigationParameters parameters)
		{

		}

		public virtual void Destroy()
		{

		}
	}
}
