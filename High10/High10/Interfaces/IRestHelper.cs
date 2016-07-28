using High10.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
    public interface IRestHelper {
        Task<List<User>> GetFriendsList(string token, long ID);
        Task<User> GetUserData(string token, long ID);
        Task<List<long>> GetUserStoryByUserID(string token, long ID);
        Task<List<long>> GetHashtagStoryByHashtag(string token, string hashtag);
        Task<List<long>> GetLocalStoryByCoordinates(string token, long latitude, long longitutde);
        Task<Picture> GetPictureByPictureID(string token, long ID);
    }
}
