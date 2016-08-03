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
using High10.Interfaces;
using High10.Views;

namespace High10.ViewModels {
  public class MasterPageViewModel : BindableBase {
    private IModelHelper m_modelHelper;
    private INavigationService m_navigationService;
    private User m_self;

    public MasterPageViewModel( IModelHelper modelHelper, INavigationService navigationService ) {
      m_modelHelper = modelHelper;
      m_navigationService = navigationService;
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
          Type page = null;
          switch ( value.NavigationPageType) {
            case NavigationPageType.Messages:
              page = typeof( MessagesPage );
              break;
            case NavigationPageType.Contacts:
              page = typeof( ContactsPage );
              break;
            case NavigationPageType.Timeline:
              page = typeof( TimelinePage );
              break;
            case NavigationPageType.Camera:
              page = typeof( CameraPage );
              break;
            case NavigationPageType.Settings:
              page = typeof( SettingsPage );
              break;
            case NavigationPageType.About:
              page = typeof( AboutPage );
              break;
            default:
              break;
          }
          MasterDetailContainerPageViewModel.NavigateTo( page );
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