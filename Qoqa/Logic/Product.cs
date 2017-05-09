using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Qoqa.Logic
{
	public class Product : INotifyPropertyChanged
	{
		private string price = string.Empty;
		public string Price
		{
			get { return price; }
			set { price = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price))); }
		}

		private string nrlprice = string.Empty;
		public string NrlPirce
		{
			get { return nrlprice; }
			set { nrlprice = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NrlPirce))); }
		}

		private string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); }
		}

		private string image = string.Empty;
		public string Image
		{
			get { return image; }
			set { image = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image))); }
		}

		private string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { description = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description))); }
		}

		public Product()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class ImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string uri = (string)value;
			if (uri == string.Empty)
				return null;
			BitmapImage imgSource = new BitmapImage(new Uri(uri));
			return imgSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
