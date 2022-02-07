using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskFromBA.Services
{
	public interface IStorageService
	{
		string SavingData(object savingData);
		T GetDataFromStorage<T>(string storageElement);
		
	}
}
