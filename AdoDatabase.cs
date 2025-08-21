using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetikus
{
    public class AdoDatabase : AbstactDatabase
    {
        private static AdoDatabase _database;
        private static OleDbConnection _connection;

        private AdoDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new OleDbConnection(connectionString);
            Console.WriteLine(_connection.ConnectionString);
        }

        public OleDbConnection Connection { get => _connection; }
        
        public override IDbDataAdapter Adapter(IDbCommand command)
                => new OleDbDataAdapter(command as OleDbCommand);

        public override IDbDataAdapter Adapter(string sqlString)
                => new OleDbDataAdapter(sqlString, _connection);

        public override IDbCommand Command(string sqlString)
                => new OleDbCommand(sqlString, _connection);

        public AdoDatabase Database { get => _database; }
    }
}
