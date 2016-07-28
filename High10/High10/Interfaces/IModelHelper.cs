using High10.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
    public interface IModelHelper {
        Task<List<User>> GetAllFriends();
        Task<List<Picture>> GetAllPictures(User friend);
        Task<List<Picture>> GetAllPictures(string hashtag);
        Task<List<Picture>> GetAllPictures(GPSLocation gpsLocation);
    }
}
