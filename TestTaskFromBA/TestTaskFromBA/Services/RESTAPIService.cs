using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTaskFromBA.AuxiliaryAdditions;

namespace TestTaskFromBA.Services
{
	class RESTAPIService : IRESTAPIServise
	{
		private HttpClient _httpClient;
		private HttpResponseMessage result;

		public HttpResponseMessage Result
		{
			get => result;
			set
			{
				result = value;
			}
		}

		public async Task<ResponseModel> GetRequest<ResponseModel>(ResponseModel response, string endPoint)
		{
			try
			{
				var json = JsonConvert.SerializeObject(response);
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"{APIConfig.URL}{endPoint}"),
					Content = new StringContent(json, Encoding.UTF8, "application/json"),
					Headers =
					{
						{ "Accept-Version", APIConfig.ACCEPT_VERSION},
						{ "Authorization", APIConfig.CLIENT_ID}
					}
				};

				var handler = new HttpClientHandler()
				{
					ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
				};
				_httpClient = new HttpClient(handler);
				Result = await _httpClient.SendAsync(request);
				var stringContent = await Result.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<ResponseModel>(stringContent);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
