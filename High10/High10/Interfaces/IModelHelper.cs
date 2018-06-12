using High10.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
  public interface IModelHelper {
    //Personal
    Task<List<User>> GetAllFriends();
    Task LoadMessagingHistory();
    Task<User> GetSelf();

    //Stories
    Task<List<Picture>> GetAllPictures( User friend );
    Task<List<Picture>> GetAllPictures( string hashtag );
    Task<List<Picture>> GetAllPictures( GPSLocation gpsLocation );

    //Chat history
    Task<List<Tuple<User, IMessage>>> GetLastMessageSentHistory();
    Task<List<TextMessage>> GetMessageHistory( User friend );
    Task<List<Picture>> GetPictureMessageHistory( User friend );
    Task<List<Tuple<User, List<Picture>>>> GetPictureMessageHistory();
    Task<List<Tuple<User, List<TextMessage>>>> GetMessageHistory();
    Task<IMessage> GetLastMessage( User friend );
  }
}
