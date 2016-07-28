using High10.ExtensionMethods;
using High10.Interfaces;
using High10.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace High10.ViewModels {
    public class LandingPageViewModel : BindableBase {
        INavigationService _navigationService;
        IModelHelper _modelHelper;
        public Command LogInButtonCommand { get; set; }
        public Command RegisterButtonCommand { get; set; }
        public Command ToLogInPageButtonCommand { get; set; }
        public Command ToRegisterPageButtonCommand { get; set; }

        private string _username;
        public string Username {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private LandingPageType _landingPageType;
        public LandingPageType LandingPageType {
            get { return _landingPageType; }
            set { SetProperty(ref _landingPageType, value); }
        }

        public LandingPageViewModel(INavigationService navigationService, IModelHelper modelHelper) {
            _navigationService = navigationService;
            LogInButtonCommand = new Command(OnLogInButtonClicked);
            RegisterButtonCommand = new Command(OnRegisterUpButtonClicked);
            ToLogInPageButtonCommand = new Command(OnToLogInPageButtonClicked);
            ToRegisterPageButtonCommand = new Command(OnToRegisterPageButtonClicked);
        }

        async void OnLogInButtonClicked() {
            //If (Username && salted password let us log in)
            await _navigationService.NavigateToAsync<MessagesPage>(animated: false);
        }

        async void OnRegisterUpButtonClicked() {
            var token = string.Empty;
            var friends = await _modelHelper.GetAllFriends();
            var friend = friends.FirstOrDefault();
            var pictures = await _modelHelper.GetAllPictures(friend);
            var picture = pictures.FirstOrDefault();
            var hit = true;
        }

        void OnToLogInPageButtonClicked() {
            Username = "";
            Password = "";
            LandingPageType = LandingPageType.LogIn;
        }

        void OnToRegisterPageButtonClicked() {
            Username = "";
            Password = "";
            LandingPageType = LandingPageType.Register;
        }
    }
}
