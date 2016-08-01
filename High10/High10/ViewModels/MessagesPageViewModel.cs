using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using High10.DataProvider;
using System.Collections.ObjectModel;
using Prism.Navigation;

namespace High10.ViewModels {
  public class MessagesPageViewModel : BindableBase, INavigationAware {
    ModelHelper m_modelHelper;
    private ObservableCollection<MessageHistoryViewModel> _messageHistoryViewModels;
    public ObservableCollection<MessageHistoryViewModel> MessageHistoryViewModels {
      get { return _messageHistoryViewModels; }
      set { SetProperty( ref _messageHistoryViewModels, value ); }
    }

    public MessagesPageViewModel( ModelHelper modelHelper ) {
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
      LoadMessageHistoryViewModels();
    }

    public void OnNavigatedFrom( NavigationParameters parameters ) { }
  }
}
