using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using High10.DataProvider;
using System.Collections.ObjectModel;
using Prism.Navigation;
using High10.Interfaces;

namespace High10.ViewModels {
  public class MessagesPageViewModel : ActionBarBasePageViewModel, INavigationAware {
    IModelHelper m_modelHelper;

    public MessagesPageViewModel( IModelHelper modelHelper ) : base() {
      m_modelHelper = modelHelper;
      MessageHistoryViewModels = new ObservableCollection<MessageHistoryViewModel>();
    }

    private async void LoadMessageHistoryViewModels() {
      var list = new ObservableCollection<MessageHistoryViewModel>();
      var messageHistory = await m_modelHelper.GetLastMessageSentHistory();
      foreach ( var message in messageHistory) {
        var user = message.Item1;
        var picture = message.Item2;
        list.Add( new MessageHistoryViewModel( user, picture ) );
      }
      MessageHistoryViewModels = list;
    }

    public void OnNavigatedTo( NavigationParameters parameters ) {
      //Load data from database
      //start thread
      LoadMessageHistoryViewModels();
    }

    private ObservableCollection<MessageHistoryViewModel> _messageHistoryViewModels;
    public ObservableCollection<MessageHistoryViewModel> MessageHistoryViewModels {
      get { return _messageHistoryViewModels; }
      set { SetProperty( ref _messageHistoryViewModels, value ); }
    }

    public MessageHistoryViewModel SelectedMessageHistoryViewModel {
      get { return null; }
      set { OnPropertyChanged(); }
    }

    public void OnNavigatedFrom( NavigationParameters parameters ) { }
  }
}
