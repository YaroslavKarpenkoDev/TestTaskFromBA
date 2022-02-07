using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFromBA.Services
{
	public interface IRESTAPIServise
	{
		Task<ResponseModel> GetRequest<ResponseModel>(ResponseModel response, string endPoint);
	}
}
