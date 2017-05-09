using Qoqa.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Qoqa
{
    public sealed partial class MainPage : Page
    {
		GetMain QoqaPage = new GetMain();
        public MainPage()
        {
            this.InitializeComponent();
			applyAcrylicAccent(BackdropGrid);
        }

		private void applyAcrylicAccent(Panel e)
		{
			_compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
			_hostSprite = _compositor.CreateSpriteVisual();
			_hostSprite.Size = new Vector2((float)BackdropGrid.ActualWidth, (float)BackdropGrid.ActualHeight);

			ElementCompositionPreview.SetElementChildVisual(
					BackdropGrid, _hostSprite);
			_hostSprite.Brush = _compositor.CreateHostBackdropBrush();
			ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
			formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
			CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
			coreTitleBar.ExtendViewIntoTitleBar = true;
		}
		Compositor _compositor;
		SpriteVisual _hostSprite;

		private void BackdropGrid_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (_hostSprite != null)
				_hostSprite.Size = e.NewSize.ToVector2();
		}
	}
}
