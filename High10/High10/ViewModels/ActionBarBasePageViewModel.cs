using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace High10.ViewModels {
  public class ActionBarBasePageViewModel : BindableBase {

    public ActionBarBasePageViewModel() {
      ToggleMasterCommand = new Command(() => MasterDetailContainerPageViewModel.ToggleMasterNavigation());
    }

    private Command _toggleMasterCommand;
    public Command ToggleMasterCommand {
      get { return _toggleMasterCommand; }
      set { SetProperty( ref _toggleMasterCommand, value ); }
    }
  }
}
