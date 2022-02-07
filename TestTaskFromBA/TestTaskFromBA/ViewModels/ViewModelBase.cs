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

		protected IRESTAPIServise Rest { get; private set; }

		protected IStorageService Storage { get; private set; }

		public ViewModelBase(INavigationService navigationService)
		{
			NavigationService = navigationService;
			Rest = new RESTAPIService();
			Storage = new StorageService();
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
