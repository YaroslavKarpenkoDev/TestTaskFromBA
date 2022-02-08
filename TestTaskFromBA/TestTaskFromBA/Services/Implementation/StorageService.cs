using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskFromBA.Resources;

namespace TestTaskFromBA.Services
{
	public class StorageService : IStorageService
	{
		public string SavingData(object savingData)
		{
			try
			{
				if (savingData != null)
				{
					var storageElement = JsonConvert.SerializeObject(savingData);
					return storageElement;
				}
				return string.Empty;
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}

		public T GetDataFromStorage<T>(string storageElement)
		{			
			T result = JsonConvert.DeserializeObject<T>(storageElement);			
			return result;
		}
	}
}
