using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private BitmapImage image = new BitmapImage();
		public BitmapImage Image
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
}
