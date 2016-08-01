using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using High10.BusinessModels;
using Xamarin.Forms;

namespace High10.ViewModels {
  public class MessageHistoryViewModel : BindableBase {
    private User m_user;
    private IMessage m_message;

    public string Name {
      get {
        return m_user?.Username ?? string.Empty;
      }
    }

    public ImageSource ImageSource {
      get {
        if (m_message is Picture) {
          return m_message.Read ? App.Images.ImageCameraWhiteOrangeBackground : App.Images.ImageCameraOrangeWhiteBackground;
        } else {
          return m_message.Read ? App.Images.ImageMessageWhiteOrangeBackground : App.Images.ImageMessageOrangeWhiteBackground;
        }
      }
    }

    public long Timestamp {
      get {
        return m_message.Timestamp;
      }
    }

    public MessageHistoryViewModel(User user, IMessage message) {
      m_user = user;
      m_message = message;
    }

    public void UpdateSentMessage(IMessage message) {
      m_message = message;
      OnPropertyChanged( () => ImageSource );
      OnPropertyChanged( () => Timestamp );
    }
  }
}
