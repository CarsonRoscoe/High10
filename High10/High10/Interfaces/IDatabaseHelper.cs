using High10.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
  public interface IDatabaseHelper {
    long ID { get; set; }

    //Personal account
    Task<long> LastImageExchangeByUser( long ID );
    Task<List<User>> GetAllFriends();
    Task<User> GetSelf();
    void SetSelf( User user );

    //Get texts/pictures
    Task<List<TextMessage>> GetTextMessageHistory( User friend, int rows = 50 );
    Task<List<Picture>> GetPictureMessageHistory( User friend, int rows = 50 );
    Task<List<Picture>> GetStory( User friend );
    Task<List<Picture>> GetStory( string hashtag );
    Task<List<Picture>> GetStory( GPSLocation gpsLocation );

    //Add to database
    void AddFriends( List<User> list );
    void AddTextMessages( User friend, List<TextMessage> task );
    void AddPictureMessages( User user, List<Picture> pictures );
    void AddPicturesToStory( string hashtag, List<Picture> pictures );
    void AddPicturesToStory( User friend, List<Picture> pictures );
    void AddPicturesToStory( GPSLocation gpsLocation, List<Picture> pictures );

    //Check if requires updating
    Task<bool> IsUserOutdated( User user, long serverTimestamp );
    Task<bool> IsUserStoryOutdated( User user, long serverTimestamp );
    Task<bool> IsHashtagStoryOutdated( string hashtag, long serverTimestamp );
    Task<bool> IsGPSStoryOutdated( GPSLocation gpsLocation, long serverTimestamp );
    Task<long> GetLocalStoryTimestamp( GPSLocation gpsLocation );
    Task<long> GetUserStoryTimestamp( User user );
    Task<long> GetHashtagStoryTimestamp( string hashtag );
  }
}
