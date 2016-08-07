using High10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.BusinessModels;
using High10.ExtensionMethods;

namespace High10.DataProvider {
  public class RestHelper : IRestHelper {
    readonly string image = "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";
    Dictionary<long, User> m_friends;
    User m_self;
    Dictionary<long, List<TextMessage>> m_textMessages;
    Dictionary<long, List<Picture>> m_pictureMessages;
    Dictionary<string, List<long>> m_storyIDsByHashtag;
    Dictionary<long, List<long>> m_storyIDsByUserID;
    Dictionary<long, Picture> m_picturesByPictureID;
    Random m_random;

    public RestHelper() {
      m_friends = new Dictionary<long, User>();
      m_storyIDsByHashtag = new Dictionary<string, List<long>>();
      m_storyIDsByUserID = new Dictionary<long, List<long>>();
      m_picturesByPictureID = new Dictionary<long, Picture>();
      m_random = new Random();
      m_textMessages = new Dictionary<long, List<TextMessage>>();
      m_pictureMessages = new Dictionary<long, List<Picture>>();

      m_self = new User
      {
        ID = 0,
        LastUpdate = DateTime.Now.Ticks,
        Base64ProfilePicture = image,
        Points = 5000,
        Username = "Carson"
      };

      for ( int i = 0; i < 50; i++ ) {
        var user = CreateUser();
        //m_friends populated
        m_friends.Add( user.ID, user );
        //m_storyIDsByUserID
        m_storyIDsByUserID.Add( user.ID, new List<long>() );
        //m_textMessages
        m_textMessages.Add( user.ID, new List<TextMessage>() );
        //m_pictureMessages
        m_pictureMessages.Add( user.ID, new List<Picture>() );
        for ( int j = 0; j < 15; j++ ) {
          var picture = CreatePicture( user.ID );
          //m_storyIDsByUserID[user.ID]
          m_storyIDsByUserID[user.ID].Add( picture.PictureID );
          if ( j % 3 == 0 ) {
            //m_pictureMessages[user.ID]
            m_pictureMessages[user.ID].Add( picture );
          }
        }
        for ( int j = 0; j < 40; j++ ) {
          var textMessage = CreateTextMessage( user.ID );
          //m_textMessages[user.ID]
          m_textMessages[user.ID].Add( textMessage );
        }
      }
    }

    public async Task<List<User>> GetFriendsList( string token, long ID ) {
      var list = new List<User>();
      foreach ( var user in m_friends ) {
        list.Add( user.Value );
      }
      return list;
    }

    public async Task<User> GetUserData( string token, long ID ) {
      return ID != 0 ? m_friends[ID] : m_self;
    }

    public async Task<Picture> GetPictureByPictureID( string token, long ID ) {
      return m_picturesByPictureID[ID];
    }

    #region Frontend-Story data
    public async Task<List<Picture>> GetHashtagStory( string token, string hashtag, long lastTimestamp = 0 ) {
      var story = new List<Picture>();
      var storyIDs = await GetHashtagStoryIDsByHashtag( token, hashtag, lastTimestamp );
      foreach ( var storyID in storyIDs ) {
        var picture = await GetPictureByPictureID( token, storyID );
        if ( picture != null ) {
          story.Add( picture );
        }
      }
      return story;
    }

    public async Task<List<Picture>> GetLocalStory( string token, long latitude, long longitude, long lastTimestamp = 0 ) {
      var story = new List<Picture>();
      var storyIDs = await GetLocalStoryIDsByCoordinates( token, latitude, longitude, lastTimestamp );
      foreach ( var storyID in storyIDs ) {
        var picture = await GetPictureByPictureID( token, storyID );
        if ( picture != null ) {
          story.Add( picture );
        }
      }
      return story;
    }

    public async Task<List<Picture>> GetUserStory( string token, long ID, long lastTimestamp = 0 ) {
      var story = new List<Picture>();
      var storyIDs = await GetUserStoryIDsByUserID( token, ID, lastTimestamp );
      foreach ( var storyID in storyIDs ) {
        var picture = await GetPictureByPictureID( token, storyID );
        if ( picture != null ) {
          story.Add( picture );
        }
      }
      return story;
    }
    #endregion

    #region Backend-Story data
    public async Task<List<long>> GetHashtagStoryIDsByHashtag( string token, string hashtag, long lastTimestamp ) {
      return m_storyIDsByHashtag[hashtag];
    }

    public async Task<List<long>> GetLocalStoryIDsByCoordinates( string token, long latitude, long longitutde, long lastTimestamp ) {
      throw new NotImplementedException();
    }

    public async Task<List<long>> GetUserStoryIDsByUserID( string token, long ID, long lastTimestamp ) {
      return m_storyIDsByUserID[ID];
    }
    #endregion

    #region Message History

    public async Task<List<TextMessage>> GetTextMessageHistoryByUserID( string token, long friendID, long lastTimestamp = 0 ) {
      if ( !m_textMessages.ContainsKey( friendID ) ) {
        m_textMessages.Add( friendID, new List<TextMessage>() );
      }
      return m_textMessages[friendID];
    }

    public async Task<List<Picture>> GetPictureMessageHistoryByUserID( string tokne, long friendID, long lastTimestamp = 0 ) {
      if ( !m_pictureMessages.ContainsKey( friendID ) ) {
        m_pictureMessages.Add( friendID, new List<Picture>() );
      }
      return m_pictureMessages[friendID];
    }
    #endregion

    #region Timestamps
    public async Task<long> GetUserLastUpdateTimestamp( string token, long ID ) {
      return m_friends[ID].LastUpdate;
    }

    public async Task<long> GetUserStoryTimestamp( string token, long ID ) {
      return m_picturesByPictureID[m_storyIDsByUserID[ID].LastOrDefault()].Timestamp;
    }

    public async Task<long> GetHashtagStoryTimestamp( string token, string hashtag ) {
      return m_picturesByPictureID[m_storyIDsByHashtag[hashtag].LastOrDefault()].Timestamp;
    }

    public async Task<long> GetLocalStoryTimestamp( string token, long latitude, long longitutde ) {
      throw new NotImplementedException();
    }
    #endregion

    #region Helper Data Generation
    TextMessage CreateTextMessage( long ID ) {
      var amOwner = m_random.Next( 0, 10 ) % 2 == 0;
      var isImage = m_random.Next( 0, 10 ) % 5 == 0;

      return new TextMessage
      {
        OwnerID = ID,
        SenderID = amOwner ? 0 : ID,
        IsImage = isImage,
        Message = isImage ? image : RandomString( 30 ),
        Timestamp = RandomTime()
      };
    }

    Picture CreatePicture( long OwnerID = 0 ) {
      var pic = new Picture
      {
        PictureID = m_random.NextLong(),
        OwnerID = OwnerID,
        Timestamp = RandomTime(),
        Duration = (byte)m_random.Next( 1, 10 ),
        Base64Image = image
      };
      m_picturesByPictureID.Add( pic.PictureID, pic );
      return pic;
    }

    User CreateUser() {
      return new User
      {
        Username = RandomString( 6 ),
        ID = m_random.NextLong(),
        Points = m_random.Next( 0, 200000 ),
        Base64ProfilePicture = m_random.Next(3) % 2 == 0 ? image : null
      };
    }

    long RandomTime() {
      return DateTime.Now.AddMinutes( m_random.Next( 0, 60 * 23 ) ).Ticks;
    }

    string RandomString( int length ) {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      return new string( Enumerable.Repeat( chars, length ).Select( s => s[m_random.Next( s.Length )] ).ToArray() );
    }
    #endregion
  }
}
