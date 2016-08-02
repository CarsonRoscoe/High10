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

    public MessageHistoryViewModel( User user, IMessage message ) {
      m_user = user;
      m_message = message;
    }

    public void UpdateSentMessage( IMessage message ) {
      m_message = message;
      _imageSource = null;
      _outlineColor = null;
      _foregroudColor = null;
      OnPropertyChanged( () => ImageSource );
      OnPropertyChanged( () => Timestamp );
      OnPropertyChanged( () => OutlineColor );
      OnPropertyChanged( () => ForegroundColor );
    }

    private Color? _foregroudColor;
    public Color ForegroundColor {
      get {
        if ( !_foregroudColor.HasValue ) {
          if ( m_message is Picture ) {
            _foregroudColor = m_message.Read ? Color.White : App.Colors.MediumOrange;
          }
          else {
            _foregroudColor = m_message.Read ? Color.White : App.Colors.LightGreen;
          }
        }
        return _foregroudColor.Value;
      }
    }

    private Color? _outlineColor;
    public Color OutlineColor {
      get {
        if (!_outlineColor.HasValue) {
          if (m_message is Picture) {
            _outlineColor = App.Colors.MediumOrange;
          } else {
            _outlineColor = App.Colors.LightGreen;
          }
        }
        return _outlineColor.Value;
      }
    }

    private string _name;
    public string Name {
      get {
        if (string.IsNullOrEmpty(_name)) {
          _name = m_user?.Username ?? string.Empty;
        }
        return _name;
      }
    }

    private ImageSource _imageSource;
    public ImageSource ImageSource {
      get {
        if (_imageSource == null ) {
          if ( m_message is Picture ) {
            _imageSource = m_message.Read ? App.Images.ImageCameraOrange : App.Images.ImageCameraWhite;
          }
          else {
            _imageSource = m_message.Read ? App.Images.ImageMessageGreen : App.Images.ImageMessageWhite;
          }
        }
        return _imageSource;
      }
    }

    public long Timestamp {
      get {
        return m_message.Timestamp;
      }
    }
  }
}
