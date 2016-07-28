using High10.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High10.BusinessModels;

namespace High10.DataProvider {
    public class DatabaseHelper : IDatabaseHelper {
        public long ID { get; private set; }
    }
}
