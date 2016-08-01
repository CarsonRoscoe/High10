using High10.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
  public interface IRestHelper {
    //Personal
    Task<List<User>> GetFriendsList( string token, long ID );
    Task<User> GetUserData( string token, long ID );

    //Stories
    Task<List<Picture>> GetUserStory( string token, long ID, long lastTimestamp = 0 );
    Task<List<Picture>> GetHashtagStory( string token, string hashtag, long lastTimestamp = 0 );
    Task<List<Picture>> GetLocalStory( string token, long latitude, long longitude, long lastTimestamp = 0 );
    Task<List<long>> GetUserStoryIDsByUserID( string token, long ID, long lastTimestamp );
    Task<List<long>> GetHashtagStoryIDsByHashtag( string token, string hashtag, long lastTimestamp );
    Task<List<long>> GetLocalStoryIDsByCoordinates( string token, long latitude, long longitutde, long lastTimestamp );

    //Texting history
    Task<List<TextMessage>> GetTextMessageHistoryByUserID( string token, long friendID, long lastTimestamp = 0 );
    Task<List<Picture>> GetPictureMessageHistoryByUserID( string tokne, long friendID, long lastTimestamp = 0 );

    //Picture by picture ID
    Task<Picture> GetPictureByPictureID( string token, long ID );

    //Last updates
    Task<long> GetUserLastUpdateTimestamp( string token, long ID );
    Task<long> GetUserStoryTimestamp( string token, long ID );
    Task<long> GetHashtagStoryTimestamp( string token, string hashtag );
    Task<long> GetLocalStoryTimestamp( string token, long latitude, long longitutde );
  }
}
