using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace High10.ViewModels {
  public class MasterDetailContainerPageViewModel : BindableBase {
    private static MasterDetailContainerPageViewModel m_instance;
    private INavigationService m_navigationService;

    public MasterDetailContainerPageViewModel( INavigationService navigationService ) {
      m_navigationService = navigationService;
      m_instance = this;
    }

    //TODO Rewrite this. Not sure how to keep MasterDetailViewModel open enough for navigation
    public static void NavigateTo( Type page ) {
      if ( m_instance != null ) {
        m_instance.NavigateToPage( page );
      }
    }

    //TODO Rewrite this.
    public static void ToggleMasterNavigation() {
      if ( m_instance != null && m_instance.ToggleMasterDetail != null ) {
        m_instance.ToggleMasterDetail();
      }
    }

    private Action _toggleMasterDetail;
    public Action ToggleMasterDetail {
      get { return _toggleMasterDetail; }
      set { SetProperty( ref _toggleMasterDetail, value ); }
    }

    private void NavigateToPage( Type page ) {
      if ( page != null ) {
        m_navigationService.NavigateAsync( page.Name );
      }
    }
  }
}
