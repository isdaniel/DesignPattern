using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class ConnectionFactory
    {

        public static IDbConcrete GetConnection(SimpleFactory.DBType type)
        {
            IDbConcrete db = null;
            switch (type)
            {
                case DBType.MySQL:
                    db=new MySQL();
                    break;
                case DBType.MSSQL:
                    db = new MSSQL();
                    break;
                case DBType.Oracle:
                    db = new Oracle();
                    break;
                default:
                    db = new MSSQL();
                    break;
            }
            return db;
        }
    }
}
