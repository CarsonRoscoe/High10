using Prism.Unity;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Prism.Events;
using High10.Views;
using High10.Interfaces;
using High10.DataProvider;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Reflection;
using System;
using High10.CustomControls;

namespace High10 {
  public partial class App : PrismApplication {
    protected override void OnInitialized() {
      InitializeComponent();
      NavigationService.NavigateAsync( nameof( LoginPage ) );
    }

    protected override void RegisterTypes() {
      Container.RegisterType<ILoginHelper, LoginHelper>();
      Container.RegisterType<IRestHelper, RestHelper>();
      Container.RegisterType<IDatabaseHelper, DatabaseHelper>();
      Container.RegisterInstance( typeof( ModelHelper ), new ModelHelper( Container.Resolve<IRestHelper>(), Container.Resolve<IDatabaseHelper>(), Container.Resolve<ILoginHelper>() ) );

      Container.RegisterTypeForNavigation<MasterDetailContainerPage>();
      Container.RegisterTypeForNavigation<MessagesPage>();
      Container.RegisterTypeForNavigation<LoginPage>();
    }

    public static class Colors {
      public static Color AppBackground { get { return GetColor(); } }
      public static Color LightGray { get { return GetColor(); } }
      public static Color DarkGray { get { return GetColor(); } }
      public static Color LightOrange { get { return GetColor(); } }
      public static Color DarkOrange { get { return GetColor(); } }
      public static Color LightRed { get { return GetColor(); } }

      private static Color GetColor( [CallerMemberName] string caller = null ) {
        if ( m_colors == null ) {
          LoadColors();
        }
        Color colorResult = Color.Default;
        m_colors.TryGetValue( caller, out colorResult );
        return colorResult;
      }

      private static Dictionary<string, Color> m_colors;

      private static void LoadColors() {
        m_colors = new Dictionary<string, Color>();
        foreach ( var pair in Current.Resources ) {
          if ( pair.Value is Color ) {
            m_colors.Add( pair.Key, (Color)pair.Value );
          }
        }
        foreach ( var property in typeof( Colors ).GetRuntimeProperties() ) {
          if ( !m_colors.ContainsKey( property.Name ) ) {
            throw new Exception( string.Format( "Color {0} not found in Resources", property.Name ) );
          }
        }
      }
    }

    public static class Images {
      public static ImageSource ImageLogoLarge { get { return GetImage(); } }
      public static ImageSource ImageLogoSmall { get { return GetImage(); } }
      public static ImageSource ImageNavigationWhite { get { return GetImage(); } }
      public static ImageSource ImageCameraWhite { get { return GetImage(); } }
      public static ImageSource ImageCameraWhiteOrangeBackground { get { return GetImage(); } }
      public static ImageSource ImageCameraOrangeWhiteBackground { get { return GetImage(); } }
      public static ImageSource ImageMessageOrangeWhiteBackground { get { return GetImage(); } }
      public static ImageSource ImageMessageWhiteOrangeBackground { get { return GetImage(); } }

      private static ImageSource GetImage( [CallerMemberName] string caller = null ) {
        if ( m_images == null ) {
          LoadImages();
        }
        ImageSource imageResult = m_images[nameof( ImageLogoSmall )];
        m_images.TryGetValue( caller, out imageResult );
        return imageResult;
      }

      private static Dictionary<string, ImageSource> m_images;

      private static void LoadImages() {
        m_images = new Dictionary<string, ImageSource>();
        foreach ( var pair in Current.Resources ) {
          if ( pair.Value is CustomImageSource ) {
            m_images.Add( pair.Key, (ImageSource)pair.Value );
          }
        }
        foreach ( var property in typeof( ImageSource ).GetRuntimeProperties() ) {
          if ( !m_images.ContainsKey( property.Name ) ) {
            throw new Exception( string.Format( "Image {0} not found in Resources", property.Name ) );
          }
        }
      }
    }
  }
}
