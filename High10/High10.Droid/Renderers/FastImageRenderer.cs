using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using High10.CustomControls;
using High10.Droid.Controls;
using High10.ImageLoaders;

[assembly: ExportRenderer (typeof(FastImage), typeof(FastImageRenderer))]
namespace High10.Droid.Controls
{
	public class FastImageRenderer : ImageRenderer
	{
		ImageLoader _imageLoader;

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
			//			if (e.OldElement != null) {
			//				((FastImage)e.OldElement).ImageProvider = null;
			//			}
			if (e.NewElement != null) {
				var fastImage = e.NewElement as FastImage;
				_imageLoader = ImageLoaderCache.GetImageLoader (this);
				SetImageUrl (fastImage.ImageUrl);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == "ImageUrl") {
				var fastImage = Element as FastImage;
				SetImageUrl (fastImage.ImageUrl);
			}
		}


		public void SetImageUrl (string imageUrl)
		{
			if (Control == null) {
				return;
			}
			if (imageUrl != null) {
				_imageLoader.DisplayImage (imageUrl, Control, -1);

			}
		}
	}
}

