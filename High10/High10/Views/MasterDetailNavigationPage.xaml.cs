using System;
using System.Runtime.CompilerServices;
using High10.ViewModels;
using Xamarin.Forms;

namespace High10.Views {
  public partial class MasterDetailNavigationPage : NavigationPage {
    public MasterDetailNavigationPage(Page page) : base( page ) { }
    
    protected override void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
      base.OnPropertyChanged( propertyName );
      if (propertyName == nameof(CurrentPage) || propertyName == nameof(ToggleMaster)) {
        var actionBarPageViewModel = CurrentPage.BindingContext as ActionBarBasePageViewModel;
        if (actionBarPageViewModel != null && ToggleMaster != null) {
          actionBarPageViewModel.ToggleMasterCommand = new Command(ToggleMaster);
        }
      }
    }

    private Action _toggleMaster;
    public Action ToggleMaster {
      get { return _toggleMaster; }
      set {
        _toggleMaster = value;
        OnPropertyChanged();
      }
    }
  }
}
