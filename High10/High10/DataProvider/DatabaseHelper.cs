using High10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.BusinessModels;

namespace High10.DataProvider {
  public class DatabaseHelper : IDatabaseHelper {
    List<User> m_friends;
    User m_self;
    Dictionary<User, List<TextMessage>> m_textMessages;
    Dictionary<long, long> m_lastMessageSentByUserID;
    Dictionary<User, List<Picture>> m_pictureMessages;
    Dictionary<User, List<Picture>> m_userStory;
    Dictionary<string, List<Picture>> m_hashtagStory;
    Dictionary<GPSLocation, List<Picture>> m_gpsStory;

    public DatabaseHelper() {
      m_friends = new List<User>();
      m_lastMessageSentByUserID = new Dictionary<long, long>();
      m_textMessages = new Dictionary<User, List<TextMessage>>();
      m_pictureMessages = new Dictionary<User, List<Picture>>();
      m_userStory = new Dictionary<User, List<Picture>>();
      m_hashtagStory = new Dictionary<string, List<Picture>>();
      m_gpsStory = new Dictionary<GPSLocation, List<Picture>>();
    }

    public long ID { get; set; }

    public void AddFriends( List<User> list ) {
      if (list != null ) {
        m_friends.AddRange( list );
      }
    }

    public void AddTextMessages( User user, List<TextMessage> texts ) {
      if (!m_textMessages.ContainsKey( user ) ) {
        m_textMessages.Add( user, new List<TextMessage>() );
      }
      m_textMessages[user].AddRange( texts );
    }

    public void AddPictureMessages( User user, List<Picture> pictures ) {
      if (m_pictureMessages?.ContainsKey( user ) ?? false) {
        foreach(var picture in m_pictureMessages[user]) {
          if (!picture.Read) {
            pictures.Insert( 0, picture );
          }
        }
        m_pictureMessages[user] = pictures;
      }
    }

    public async Task<List<User>> GetAllFriends() {
      return m_friends ?? new List<User>();
    }

    public async Task<List<TextMessage>> GetTextMessageHistory( User friend, int rows = 50 ) {
      if (!m_textMessages.ContainsKey( friend ) ) {
        m_textMessages.Add(friend, new List<TextMessage>());
      } 
      return m_textMessages[friend].Take( rows ).ToList();
    }

    public async Task<long> LastImageExchangeByUser( long ID ) {
      if (!m_lastMessageSentByUserID.ContainsKey(ID)) {
        return m_lastMessageSentByUserID[ID];
      }
      return default( long );
    }

    public async Task<List<Picture>> GetPictureMessageHistory( User friend, int rows = 50 ) {
      if (!m_pictureMessages.ContainsKey( friend )) {
        m_pictureMessages.Add( friend, new List<Picture>() );
      }
      return m_pictureMessages[friend].Take( rows ).ToList();
    }

    public async Task<bool> IsUserOutdated( User user, long serverTimestamp ) {
      return user.LastUpdate < serverTimestamp;
    }

    public async Task<bool> IsUserStoryOutdated( User user, long serverTimestamp ) {
      if (m_userStory.ContainsKey( user ) ) {
        return (m_userStory[user].LastOrDefault()?.Timestamp ?? 0) < serverTimestamp;
      }
      return true;
    }

    public async Task<bool> IsHashtagStoryOutdated( string hashtag, long serverTimestamp ) {
      if ( m_hashtagStory.ContainsKey( hashtag ) ) {
        return (m_hashtagStory[hashtag].LastOrDefault()?.Timestamp ?? 0) < serverTimestamp;
      }
      return true;
    }

    public async Task<bool> IsGPSStoryOutdated( GPSLocation gpsLocation, long serverTimestamp ) {
      if ( m_gpsStory.ContainsKey( gpsLocation ) ) {
        return (m_gpsStory[gpsLocation].LastOrDefault()?.Timestamp ?? 0) < serverTimestamp;
      }
      return true;
    }

    public async Task<List<Picture>> GetStory( User friend ) {
      if (m_userStory.ContainsKey( friend ) ) {
        return m_userStory[friend];
      } else {
        return new List<Picture>();
      }
    }

    public async Task<List<Picture>> GetStory( string hashtag ) {
      if ( m_hashtagStory.ContainsKey( hashtag ) ) {
        return m_hashtagStory[hashtag];
      }
      else {
        return new List<Picture>();
      }
    }

    public async Task<List<Picture>> GetStory( GPSLocation gpsLocation ) {
      if ( m_gpsStory.ContainsKey( gpsLocation ) ) {
        return m_gpsStory[gpsLocation];
      }
      else {
        return new List<Picture>();
      }
    }

    public void AddPicturesToStory( GPSLocation gpsLocation, List<Picture> pictures ) {
      if (!m_gpsStory.ContainsKey(gpsLocation)) {
        m_gpsStory.Add( gpsLocation, new List<Picture>() );
      }
      m_gpsStory[gpsLocation].AddRange( pictures );
    }

    public void AddPicturesToStory( string hashtag, List<Picture> pictures ) {
      if ( !m_hashtagStory.ContainsKey( hashtag ) ) {
        m_hashtagStory.Add( hashtag, new List<Picture>() );
      }
      m_hashtagStory[hashtag].AddRange( pictures );
    }

    public void AddPicturesToStory( User friend, List<Picture> pictures ) {
      if ( !m_userStory.ContainsKey( friend ) ) {
        m_userStory.Add( friend, new List<Picture>() );
      }
      m_userStory[friend].AddRange( pictures );
    }

    public async Task<long> GetLocalStoryTimestamp( GPSLocation gpsLocation ) {
      if ( m_gpsStory.ContainsKey( gpsLocation ) ) {
        return m_gpsStory[gpsLocation].LastOrDefault()?.Timestamp ?? 0;
      }
      return 0;
    }

    public async Task<long> GetUserStoryTimestamp( User user ) {
      if ( m_userStory.ContainsKey( user ) ) {
        return m_userStory[user].LastOrDefault()?.Timestamp ?? 0;
      }
      return 0;
    }

    public async Task<long> GetHashtagStoryTimestamp( string hashtag ) {
      if ( m_hashtagStory.ContainsKey( hashtag ) ) {
        return m_hashtagStory[hashtag].LastOrDefault()?.Timestamp ?? 0;
      }
      return 0;
    }

    public async Task<User> GetSelf() {
      return m_self;
    }

    public void SetSelf( User user ) {
      m_self = user;
    }
  }
}
