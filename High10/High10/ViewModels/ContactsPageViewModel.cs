using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Prism.Navigation;
using High10.Interfaces;
using High10.DataStructures;

namespace High10.ViewModels {
  public class ContactsPageViewModel : ActionBarBasePageViewModel, INavigationAware {
    private IModelHelper m_modelHelper;

    public ContactsPageViewModel(IModelHelper modelHelper) {
      m_modelHelper = modelHelper;
      ContactViewModels = new SearchableObservableCollection();
    }

    public void OnNavigatedTo( NavigationParameters parameters ) {
      LoadContactViewModels();
    }

    private async void LoadContactViewModels() {
      ContactViewModels.Clear();
      foreach(var user in await m_modelHelper.GetAllFriends()) {
        ContactViewModels.Add( new ContactViewModel( user ) );
      }
    }

    private SearchableObservableCollection _contactViewModels;
    public SearchableObservableCollection ContactViewModels {
      get { return _contactViewModels; }
      set { SetProperty( ref _contactViewModels, value ); }
    }

    public string SearchBarText {
      set {
        ContactViewModels.Search( value ?? string.Empty );
      }
    }

    public void OnNavigatedFrom( NavigationParameters parameters ) {}
  }
}
