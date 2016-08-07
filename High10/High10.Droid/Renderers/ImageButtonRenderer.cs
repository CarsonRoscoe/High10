using System.ComponentModel;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Graphics.Drawables;
using High10.CustomControls;
using High10.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//Written by George Cook
[assembly: ExportRenderer( typeof( ImageButton ), typeof( ImageButtonRenderer ) )]
namespace High10.Droid.CustomRenderers {

  public class ImageButtonRenderer : ButtonRenderer {

    public ImageButtonRenderer() {
      SetWillNotDraw( false );
    }

    protected override void OnElementChanged( ElementChangedEventArgs<Xamarin.Forms.Button> e ) {
      base.OnElementChanged( e );
      Control.SetText( string.Empty, Android.Widget.TextView.BufferType.Normal );
      var imageButton = e.NewElement as ImageButton;
      UpdateBackgroundColor( imageButton );

      var imageSource = imageButton?.ImageSource;
      if ( imageSource != null ) {
        m_bitmapTask = new StreamImagesourceHandler().LoadImageAsync( imageSource, Forms.Context );
        m_bitmapTask.ContinueWith( t =>
        {
          Device.BeginInvokeOnMainThread( Invalidate );
        } );
      }
    }

    private void UpdateBackgroundColor( ImageButton imageButton ) {
      m_backgroundColor = Android.Graphics.Color.Transparent;
      if ( imageButton != null ) {

        if ( imageButton.BackgroundColor == Xamarin.Forms.Color.Default || imageButton.BackgroundColor == Xamarin.Forms.Color.Transparent ) {
          var parentView = imageButton?.Parent as Xamarin.Forms.View;
          if ( parentView != null ) {
            m_backgroundColor = parentView.BackgroundColor.ToAndroid();
          }
        }
        else {
          m_backgroundColor = imageButton.BackgroundColor.ToAndroid();
        }


      }
    }

    protected override void OnElementPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      base.OnElementPropertyChanged( sender, e );
      if ( e.PropertyName == "BackgroundColor" ) {
        UpdateBackgroundColor( Element as ImageButton );
        Invalidate();
      }
    }

    Android.Graphics.Color m_backgroundColor = Android.Graphics.Color.Transparent;

    Task<Android.Graphics.Bitmap> m_bitmapTask;

    public override void Draw( Android.Graphics.Canvas canvas ) {

      var imageButton = Element as ImageButton;
      if ( imageButton != null ) {
        var bounds = new Rect();
        GetDrawingRect( bounds );
        var paint = new Paint() { Color = m_backgroundColor };
        canvas.DrawRect( bounds, paint );
        if ( m_bitmapTask?.IsCompleted ?? false ) {
          var bitmap = m_bitmapTask.Result;
          Rect bitmapRect = new Rect( 0, 0, bitmap.Width, bitmap.Height );
          var bitmapAspect = (float)bitmap.Width / (float)bitmap.Height;
          var boundsAspect = (float)bounds.Width() / (float)bounds.Height();
          Rect destRect;
          if ( bitmapAspect >= boundsAspect ) { // Fit to width
            var destHeight = (int)(bounds.Width() / bitmapAspect);
            var top = (bounds.Height() - destHeight) / 2;
            destRect = new Rect( 0, top, bounds.Width(), top + destHeight );
          }
          else { // fit to height
            var destWidth = (int)(bounds.Height() * bitmapAspect);
            var left = (bounds.Width() - destWidth) / 2;
            destRect = new Rect( left, 0, left + destWidth, bounds.Height() );
          }
          var width = bitmap.GetScaledWidth( canvas );
          canvas.DrawBitmap( m_bitmapTask.Result, bitmapRect, destRect, null );
        }
      }
      else {
        base.Draw( canvas );
      }
    }

  }
}