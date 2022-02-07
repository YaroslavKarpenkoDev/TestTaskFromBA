using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskFromBA.Models
{
	public class ImageResponseModel
	{
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public string promoted_at { get; set; }
		public string description { get; set; }
		public string alt_description { get; set; }
		public UrlsModel urls { get; set; }
	}
}
