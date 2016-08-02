using High10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.BusinessModels;

namespace High10.DataProvider {
  public class ModelHelper : IModelHelper {
    IRestHelper m_restHelper;
    IDatabaseHelper m_databaseHelper;
    ILoginHelper m_loginHelper;

    public ModelHelper( IRestHelper restHelper, IDatabaseHelper databaseHelper, ILoginHelper loginHelper ) {
      m_restHelper = restHelper;
      m_databaseHelper = databaseHelper;
      m_loginHelper = loginHelper;
      m_databaseHelper.ID = 0;
    }

    public async Task<List<User>> GetAllFriends() {
      if ( (await m_databaseHelper.GetAllFriends()).Count == 0 ) {
        m_databaseHelper.AddFriends( await m_restHelper.GetFriendsList( m_loginHelper.Token, m_databaseHelper.ID ) );
      }
      return await m_databaseHelper.GetAllFriends();
    }

    public async Task<List<Picture>> GetAllPictures( GPSLocation gpsLocation ) {
      var serverTimestamp = await m_restHelper.GetLocalStoryTimestamp(m_loginHelper.Token, gpsLocation.Latitude, gpsLocation.Longitude);
      var databaseTimestamp = await m_databaseHelper.GetLocalStoryTimestamp( gpsLocation );

      if ( (await m_databaseHelper.IsGPSStoryOutdated(gpsLocation, serverTimestamp))) {
        m_databaseHelper.AddPicturesToStory( gpsLocation, await m_restHelper.GetLocalStory( m_loginHelper.Token, gpsLocation.Latitude, gpsLocation.Longitude, databaseTimestamp ));
      }

      return await m_databaseHelper.GetStory( gpsLocation );
    }

    public async Task<List<Picture>> GetAllPictures( string hashtag ) {
      var serverTimestamp = await m_restHelper.GetHashtagStoryTimestamp( m_loginHelper.Token, hashtag );
      var databaseTimestamp = await m_databaseHelper.GetHashtagStoryTimestamp( hashtag );
      if ( (await m_databaseHelper.IsHashtagStoryOutdated( hashtag, serverTimestamp )) ) {
        m_databaseHelper.AddPicturesToStory( hashtag, await m_restHelper.GetHashtagStory( m_loginHelper.Token, hashtag, databaseTimestamp ) );
      }
      return await m_databaseHelper.GetStory( hashtag );
    }

    public async Task<List<Picture>> GetAllPictures( User friend ) {
      var serverTimestamp = await m_restHelper.GetUserStoryTimestamp( m_loginHelper.Token, friend.ID );
      var databaseTimestamp = await m_databaseHelper.GetUserStoryTimestamp( friend );

      if ( (await m_databaseHelper.IsUserOutdated( friend, serverTimestamp )) ) {
        m_databaseHelper.AddPicturesToStory( friend, await m_restHelper.GetLocalStory( m_loginHelper.Token, friend.ID, databaseTimestamp ) );
      }

      return await m_databaseHelper.GetStory( friend );
    }

    public async Task<List<TextMessage>> GetMessageHistory( User friend ) {
      if ( (await m_databaseHelper.GetTextMessageHistory( friend )).Count == 0 ) {
        m_databaseHelper.AddTextMessages( friend, await m_restHelper.GetTextMessageHistoryByUserID( m_loginHelper.Token, friend.ID ) );
      }
      return await m_databaseHelper.GetTextMessageHistory( friend );
    }

    public async Task<List<Tuple<User, List<TextMessage>>>> GetMessageHistory() {
      var messageHistory = new List<Tuple<User, List<TextMessage>>>();
      foreach ( var user in await GetAllFriends() ) {
        var friendsHistory = await GetMessageHistory( user );
        messageHistory.Add( new Tuple<User, List<TextMessage>>( user, friendsHistory ) );
      }
      return messageHistory;
    }

    public async Task<List<Picture>> GetPictureMessageHistory( User friend ) {
      if ( (await m_databaseHelper.GetPictureMessageHistory( friend )).Count == 0 ) {
        m_databaseHelper.AddPictureMessages( friend, await m_restHelper.GetPictureMessageHistoryByUserID( m_loginHelper.Token, friend.ID ) );
      }
      return await m_databaseHelper.GetPictureMessageHistory( friend );
    }

    public async Task<List<Tuple<User, List<Picture>>>> GetPictureMessageHistory() {
      var messageHistory = new List<Tuple<User, List<Picture>>>();
      foreach ( var user in await GetAllFriends() ) {
        var friendsHistory = await GetPictureMessageHistory( user );
        messageHistory.Add( new Tuple<User, List<Picture>>( user, friendsHistory ) );
      }
      return messageHistory;
    }

    public async Task<List<Tuple<User, IMessage>>> GetLastMessageSentHistory() {
      var messageHistory = new List<Tuple<User, IMessage>>();
      foreach ( var user in await GetAllFriends() ) {
        var lastMessage = await GetLastMessage( user );
        messageHistory.Add( new Tuple<User, IMessage>( user, lastMessage ) );
      }
      return messageHistory.OrderByDescending(x => x.Item2.Timestamp).ToList();
    }

    public async Task<IMessage> GetLastMessage( User friend ) {
      var textMessage = await GetLastTextMessage( friend );
      var pictureMessage = await GetLastPictureMessage( friend );
      return ((textMessage?.Timestamp ?? 0) > (pictureMessage?.Timestamp ?? 0)) ? (IMessage)textMessage : pictureMessage;
    }

    private async Task<TextMessage> GetLastTextMessage( User friend ) {
      return (await m_databaseHelper.GetTextMessageHistory( friend, 1 )).LastOrDefault();
    }

    private async Task<Picture> GetLastPictureMessage( User friend ) {
      return (await m_databaseHelper.GetPictureMessageHistory( friend, 1 )).LastOrDefault();
    }

    public async Task LoadMessagingHistory() {
      await GetMessageHistory();
      await GetPictureMessageHistory();
    }

    public async Task<User> GetSelf() {
      User self = await m_databaseHelper.GetSelf();
      if (self == null ) {
        m_databaseHelper.SetSelf( await m_restHelper.GetUserData(m_loginHelper.Token, m_databaseHelper.ID) );
        self = await m_databaseHelper.GetSelf();
      }
      return self;
    }
  }
}
