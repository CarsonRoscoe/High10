using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Droid;

namespace High10.Droid {
  [Activity( Label = "High10", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity {
    protected override void OnCreate( Bundle bundle ) {
      base.OnCreate( bundle );

      global::Xamarin.Forms.Forms.SetTitleBarVisibility( Xamarin.Forms.AndroidTitleBarVisibility.Never );

      global::Xamarin.Forms.Forms.Init( this, bundle );
      ImageCircleRenderer.Init();
      LoadApplication( new App() );
    }
  }
}

