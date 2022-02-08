using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTaskFromBA.AuxiliaryAdditions;

namespace TestTaskFromBA.Services
{
	public class RESTAPIService : IRESTAPIService
	{
		private HttpClient _httpClient;
		private HttpResponseMessage result;

		public HttpResponseMessage Result { get; set; }

		public async Task<ResponseModel> GetRequest<ResponseModel>(string endPoint)
		{
			try
			{
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"{APIConfig.URL}{endPoint}"),
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
