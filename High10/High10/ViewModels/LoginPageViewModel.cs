using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using High10.Interfaces;
using Xamarin.Forms;
using High10.Views;
using High10.ExtensionMethods;
using High10.DataProvider;

namespace High10.ViewModels {
  public class LoginPageViewModel : BindableBase {
    INavigationService m_navigationService;
    IModelHelper m_modelHelper;
    ILoginHelper m_loginHelper;

    public LoginPageViewModel( INavigationService navigationService, ILoginHelper loginHelper, ModelHelper modelHelper ) {
      m_navigationService = navigationService;
      m_loginHelper = loginHelper;
      m_modelHelper = modelHelper;
      LogInButtonCommand = new Command( OnLogInButtonClicked );
      RegisterButtonCommand = new Command( OnRegisterUpButtonClicked );
      ToLogInPageButtonCommand = new Command( OnToLogInPageButtonClicked );
      ToRegisterPageButtonCommand = new Command( OnToRegisterPageButtonClicked );
    }

    async void OnLogInButtonClicked() {
      var token = string.Empty;
      if ( !string.IsNullOrEmpty( token = await m_loginHelper.TryLogin( Username, Password ) ) ) {
        await m_modelHelper.LoadMessagingHistory();
        await m_navigationService.NavigateToAsync<MasterDetailContainerPage, MasterDetailNavigationPage, MessagesPage>( animated: false );
      }
    }

    void OnRegisterUpButtonClicked() {
    }

    void OnToLogInPageButtonClicked() {
      Username = "";
      Password = "";
      LoginPageType = LoginPageType.LogIn;
    }

    void OnToRegisterPageButtonClicked() {
      Username = "";
      Password = "";
      LoginPageType = LoginPageType.Register;
    }

    public Command LogInButtonCommand { get; set; }
    public Command RegisterButtonCommand { get; set; }
    public Command ToLogInPageButtonCommand { get; set; }
    public Command ToRegisterPageButtonCommand { get; set; }

    private string _username;
    public string Username {
      get { return _username; }
      set { SetProperty( ref _username, value ); }
    }

    private string _password;
    public string Password {
      get { return _password; }
      set { SetProperty( ref _password, value ); }
    }

    private LoginPageType _loginPageType;
    public LoginPageType LoginPageType {
      get { return _loginPageType; }
      set { SetProperty( ref _loginPageType, value ); }
    }
  }
}
