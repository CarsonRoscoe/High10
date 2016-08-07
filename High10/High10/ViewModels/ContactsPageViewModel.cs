using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Prism.Navigation;
using High10.Interfaces;

namespace High10.ViewModels {
  public class ContactsPageViewModel : ActionBarBasePageViewModel, INavigationAware {
    private IModelHelper m_modelHelper;
    private ObservableCollection<ContactViewModel> m_allContactViewModels;

    public ContactsPageViewModel(IModelHelper modelHelper) {
      m_modelHelper = modelHelper;
      SearchListCommand = new Command( OnSearchList );
      ContactViewModels = new ObservableCollection<ContactViewModel>();
    }

    public void OnNavigatedTo( NavigationParameters parameters ) {
      LoadContactViewModels();
    }

    private async void LoadContactViewModels() {
      ContactViewModels.Clear();
      foreach(var user in await m_modelHelper.GetAllFriends()) {
        ContactViewModels.Add( new ContactViewModel( user ) );
      }
      m_allContactViewModels = new ObservableCollection<ContactViewModel>(ContactViewModels);
    }

    private ObservableCollection<ContactViewModel> _contactViewModels;
    public ObservableCollection<ContactViewModel> ContactViewModels {
      get { return _contactViewModels; }
      set { SetProperty( ref _contactViewModels, value ); }
    }

    private string _searchBarText;
    public string SearchBarText {
      get { return _searchBarText; }
      set { SetProperty( ref _searchBarText, value ); }
    }

    public Command SearchListCommand { get; private set; }
    public void OnSearchList() {

    }

    public void OnNavigatedFrom( NavigationParameters parameters ) {}
  }
}
