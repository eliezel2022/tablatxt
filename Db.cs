using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;

namespace XventoryLDB
{
    class Db
    {
        public static dynamic connect()
        {
            return new LiteDatabase("mydata.db");
        }
    }
}
