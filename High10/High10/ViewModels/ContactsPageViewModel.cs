using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace High10.ViewModels {
  public class ContactsPageViewModel : ActionBarBasePageViewModel {
    public ContactsPageViewModel() {
      SearchListCommand = new Command( OnSearchList );
    }

    private string _searchBarText;
    public string SearchBarText {
      get { return _searchBarText; }
      set { SetProperty( ref _searchBarText, value ); }
    }

    public Command SearchListCommand { get; private set; }
    public void OnSearchList() {

    }
  }
}
