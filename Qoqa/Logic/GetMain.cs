using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qoqa.Logic
{
	public class GetMain
	{
		string baseURL = @"http://qoqa.ch";
		string page = string.Empty;
		public Product Product = new Product();

		public GetMain()
		{
			GetPage();
		}

		private async void GetPage()
		{
			HttpClient client = new HttpClient();
			page = await client.GetStringAsync(baseURL);
			ParsePageToProduct(page);
		}

		private void ParsePageToProduct(string page)
		{
			
		}
	}
}
