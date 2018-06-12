using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.CustomControls {
  public class ImageButton : Button {

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create( "ImageSource", typeof( ImageSource ), typeof( ImageButton ) );

    public ImageSource ImageSource {
      get {
        return (ImageSource)GetValue( ImageSourceProperty );
      }
      set {
        SetValue( ImageSourceProperty, value );
      }
    }
  }
}
