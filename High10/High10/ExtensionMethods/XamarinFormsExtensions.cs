using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace High10.ExtensionMethods {
  public static class XamarinFormsExtensionMethods {
    public static ImageSource ToImageSource( this string @this ) {
      return ImageSource.FromStream( () => new MemoryStream( Convert.FromBase64String( @this ) ) );
    }
  }
}
