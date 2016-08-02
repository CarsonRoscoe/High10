using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using High10.DataProvider;
using Xamarin.Forms;
using High10.BusinessModels;
using Prism.Navigation;
using High10.ExtensionMethods;

namespace High10.ViewModels {
  public class MasterPageViewModel : BindableBase {
    private ModelHelper m_modelHelper;
    private User m_self;

    public MasterPageViewModel( ModelHelper modelHelper ) {
      m_modelHelper = modelHelper;
      LoadPage();
    }

    public async void LoadPage() {
      m_self = await m_modelHelper.GetSelf();
      OnPropertyChanged( () => Portrait );
      OnPropertyChanged( () => Username );
      OnPropertyChanged( () => Points );
      var list = new List<NavigationViewModel>();
      foreach( NavigationPageType type in Enum.GetValues(typeof(NavigationPageType))) {
        list.Add( new NavigationViewModel( type ) );
      }
      NavigationViewModels = list;
    }

    private List<NavigationViewModel> _navigationViewModels;
    public List<NavigationViewModel> NavigationViewModels {
      get { return _navigationViewModels; }
      set { SetProperty( ref _navigationViewModels, value ); }
    }
    
    public NavigationViewModel SelectedNavigationViewModel {
      get {
        return null;
      }
      set {
        if (value != null ) {
          switch ( value.NavigationPageType ) {
            case NavigationPageType.Messages:
              break;
            case NavigationPageType.Contacts:
              break;
            case NavigationPageType.Stories:
              break;
            case NavigationPageType.Camera:
              break;
            case NavigationPageType.Settings:
              break;
            case NavigationPageType.About:
              break;
            default:
              break;
          }
        }
      }
    }

    public ImageSource Portrait {
      get { return m_self?.Base64ProfilePicture.ToImageSource() ?? null; }
    }

    public string Username {
      get { return m_self?.Username ?? string.Empty; }
    }

    public string Points {
      get { return (m_self?.Points ?? 0).ToString(); }
    }
  }
}