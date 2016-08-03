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
      Container.RegisterInstance( typeof( IModelHelper ), new ModelHelper( Container.Resolve<IRestHelper>(), Container.Resolve<IDatabaseHelper>(), Container.Resolve<ILoginHelper>() ) );

      Container.RegisterTypeForNavigation<MasterDetailContainerPage>();
      Container.RegisterTypeForNavigation<MessagesPage>();
      Container.RegisterTypeForNavigation<LoginPage>();
      Container.RegisterTypeForNavigation<MasterDetailNavigationPage>();
      Container.RegisterTypeForNavigation<ContactsPage>();
      Container.RegisterTypeForNavigation<TimelinePage>();
      Container.RegisterTypeForNavigation<CameraPage>();
      Container.RegisterTypeForNavigation<SettingsPage>();
      Container.RegisterTypeForNavigation<AboutPage>();
    }

    public static class Colors {
      public static Color DarkText { get { return GetColor(); } }
      public static Color LightText { get { return GetColor(); } }
      public static Color DarkGreen { get { return GetColor(); } }
      public static Color MediumGreen { get { return GetColor(); } }
      public static Color LightGreen { get { return GetColor(); } }
      public static Color LightOrange { get { return GetColor(); } }
      public static Color MediumOrange { get { return GetColor(); } }
      public static Color MediumPink { get { return GetColor(); } }
      public static Color DarkGray { get { return GetColor(); } }
      public static Color LightGray { get { return GetColor(); } }

      private static Color GetColor( [CallerMemberName] string caller = null ) {
        if ( m_colors == null ) {
          LoadColors();
        }
        Color colorResult = Color.Default;
        m_colors.TryGetValue( string.Format( "Color{0}", caller ), out colorResult );
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
          if ( !m_colors.ContainsKey( string.Format( "Color{0}", property.Name ) ) ) {
            throw new Exception( string.Format( "Color {0} not found in Resources", property.Name ) );
          }
        }
      }
    }

    public static class Images {
      public static CustomImageSource ImageLogoLarge { get { return GetImage(); } }
      public static CustomImageSource ImageLogoSmall { get { return GetImage(); } }
      public static CustomImageSource ImageNavigationWhite { get { return GetImage(); } }
      public static CustomImageSource ImageCameraWhite { get { return GetImage(); } }
      public static CustomImageSource ImageCameraOrange { get { return GetImage(); } }
      public static CustomImageSource ImageMessageGreen { get { return GetImage(); } }
      public static CustomImageSource ImageMessageWhite { get { return GetImage(); } }
      public static CustomImageSource ImageContactsWhite { get { return GetImage(); } }
      public static CustomImageSource ImageSettingsWhite { get { return GetImage(); } }
      public static CustomImageSource ImageInfoWhite { get { return GetImage(); } }
      public static CustomImageSource ImageTimelineWhite { get { return GetImage(); } }

      private static CustomImageSource GetImage( [CallerMemberName] string caller = null ) {
        if ( m_images == null ) {
          LoadImages();
        }
        CustomImageSource imageResult = m_images[nameof( ImageLogoSmall )];
        m_images.TryGetValue( caller, out imageResult );
        return imageResult;
      }

      private static Dictionary<string, CustomImageSource> m_images;

      private static void LoadImages() {
        m_images = new Dictionary<string, CustomImageSource>();
        foreach ( var pair in Current.Resources ) {
          if ( pair.Value is CustomImageSource ) {
            m_images.Add( pair.Key, (CustomImageSource)pair.Value );
          }
        }
        foreach ( var property in typeof( Images ).GetRuntimeProperties() ) {
          if ( !m_images.ContainsKey( property.Name ) ) {
            throw new Exception( string.Format( "Image {0} not found in Resources", property.Name ) );
          }
        }
      }
    }
  }
}
