using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace High10.ViewModels {
  public enum NavigationPageType { Messages, Contacts, Timeline, Camera, Settings, About }

  public class NavigationViewModel : BindableBase {
    public NavigationViewModel(NavigationPageType navigationPageType) {
      NavigationPageType = navigationPageType;
    }

    public NavigationPageType NavigationPageType { get; set; }

    public string Text {
      get {
        switch ( NavigationPageType ) {
          case NavigationPageType.Messages:
            return "Messages";
          case NavigationPageType.Camera:
            return "Camera";
          case NavigationPageType.Timeline:
            return "Timelines";
          case NavigationPageType.Contacts:
            return "Contacts";
          case NavigationPageType.Settings:
            return "Settings";
          case NavigationPageType.About:
            return "About";
          default:
            return string.Empty;
        }
      }
    }

    private ImageSource _imageSource;
    public ImageSource ImageSource {
      get {
        if (_imageSource == null ) {
          switch ( NavigationPageType ) {
            case NavigationPageType.Messages:
              _imageSource = App.Images.ImageMessageWhite;
              break;
            case NavigationPageType.Camera:
              _imageSource = App.Images.ImageCameraWhite;
              break;
            case NavigationPageType.Timeline:
              _imageSource = App.Images.ImageTimelineWhite;
              break;
            case NavigationPageType.Contacts:
              _imageSource = App.Images.ImageContactsWhite;
              break;
            case NavigationPageType.Settings:
              _imageSource = App.Images.ImageSettingsWhite;
              break;
            case NavigationPageType.About:
              _imageSource = App.Images.ImageInfoWhite;
              break;
            default:
              _imageSource = App.Images.ImageMessageWhite;
              break;
          }
        }
        return _imageSource;
      }
    }
  }
}
