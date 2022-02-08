using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFromBA.Services
{
	public interface IRESTAPIService
	{
		Task<ResponseModel> GetRequest<ResponseModel>( string endPoint);
	}
}
