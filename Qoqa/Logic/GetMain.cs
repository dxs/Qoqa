using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

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
			ParseName(page);
			ParseDescription(page);
			ParsePrice(page);
			ParseNrlPrice(page);
			ParseImage(page);
		}

		private void ParseDescription(string page)
		{
			try
			{
				string[] tmp = page.Split(new string[] { "<meta property=\"og:description\" content=\"" }, StringSplitOptions.RemoveEmptyEntries);
				string tmpstr = tmp[1];
				tmp = tmpstr.Split(new string[] { "\"/>" }, StringSplitOptions.RemoveEmptyEntries);
				tmpstr = tmp[0];
				Product.Description = tmpstr;
			}
			catch (Exception e)
			{
				//TODO
			}
		}

		private void ParseImage(string page)
		{
			try
			{
				string[] tmp = page.Split(new string[] { "<meta property=\"og:image\" content=\"" }, StringSplitOptions.RemoveEmptyEntries);
				string tmpstr = tmp[1];
				tmp = tmpstr.Split(new string[] { "\"/>" }, StringSplitOptions.RemoveEmptyEntries);
				tmpstr = tmp[0];
				Product.Image = new BitmapImage(new Uri(tmpstr));
			}
			catch (Exception e)
			{
				//TODO
			}
		}

		private void ParseNrlPrice(string page)
		{
			try
			{
				string[] tmp = page.Split(new string[] { "\"monetized_regular_price\":\"" }, StringSplitOptions.RemoveEmptyEntries);
				string tmpstr = tmp[1];
				tmp = tmpstr.Split(new string[] { ".-" }, StringSplitOptions.RemoveEmptyEntries);
				tmpstr = tmp[0];
				Product.NrlPirce = tmpstr;
			}
			catch (Exception e)
			{
				//TODO
			}
		}

		private void ParsePrice(string page)
		{
			try
			{
				string[] tmp = page.Split(new string[] { "\"monetized_lot_price\":\"" }, StringSplitOptions.RemoveEmptyEntries);
				string tmpstr = tmp[1];
				tmp = tmpstr.Split(new string[] { ".-" }, StringSplitOptions.RemoveEmptyEntries);
				tmpstr = tmp[0];
				Product.Price = tmpstr;
			}
			catch (Exception e)
			{
				//TODO
			}
		}

		private void ParseName(string page)
		{
			try
			{
				string[] tmp = page.Split(new string[] { "<meta name=\"title\" content=\"" }, StringSplitOptions.RemoveEmptyEntries);
				string tmpstr = tmp[1];
				tmp = tmpstr.Split(new string[] { "\"/>" }, StringSplitOptions.RemoveEmptyEntries);
				tmpstr = tmp[0];
				Product.Name = tmpstr;
			}
			catch (Exception e)
			{
				//TODO
			}
		}
	}
}
