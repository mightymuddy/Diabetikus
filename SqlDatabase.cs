using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;

namespace Diabetikus
{
 


    public class SqlDatabase : AbstactDatabase
    {

        private static SqlDatabase _database;
        private SqlConnection _connection;

        public static SqlDatabase _getInstance()
        {
            _database = new SqlDatabase();
            return _database;
        }

        private SqlDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            Console.WriteLine(_connection.ConnectionString);
        }

        public SqlConnection Connection { get => _connection; }

        public override IDbDataAdapter Adapter(IDbCommand command)
            => new SqlDataAdapter(command as SqlCommand);

        public override IDbDataAdapter Adapter(string sqlString)
            => new SqlDataAdapter(sqlString, _connection);

        public override IDbCommand Command(string sqlString) => new SqlCommand(sqlString, _connection);

      
    }
}
