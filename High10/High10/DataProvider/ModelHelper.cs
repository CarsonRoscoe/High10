using High10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.BusinessModels;

namespace High10.DataProvider {
    public class ModelHelper : IModelHelper {
        IRestHelper _restHelper;
        IDatabaseHelper _databaseHelper;
        ILoginHelper _loginHelper;

        public ModelHelper(IRestHelper restHelper, IDatabaseHelper databaseHelper, ILoginHelper loginHelper) {
            _restHelper = restHelper;
            _databaseHelper = databaseHelper;
            _loginHelper = loginHelper;
        }

        public async Task<List<User>> GetAllFriends() {
            //if we have outdated data in database or no data
                var newData = await _restHelper.GetFriendsList(_loginHelper.Token, _databaseHelper.ID);
            //  await storing new data
                return newData;
            //else
            //  await data fetching from database
            //  return old data
        }

        public Task<List<Picture>> GetAllPictures(GPSLocation gpsLocation) {
            throw new NotImplementedException();
        }

        public Task<List<Picture>> GetAllPictures(string hashtag) {
            throw new NotImplementedException();
        }

        public Task<List<Picture>> GetAllPictures(User friend) {
            throw new NotImplementedException();
        }
    }
}
