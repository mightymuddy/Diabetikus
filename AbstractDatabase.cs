using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetikus
{
    public enum CmdType
    {
        Select,
        Insert,
        Update,
        Delete

    }

    public enum JoinType
    {
        Inner,
        Outer,
        left,
        right,
        leftOuter,
        rightOuter
    }

    
    public abstract class AbstactDatabase
    {
        private static AbstactDatabase _database;
        private static IDbConnection _connection;

        public virtual IDbConnection Connection { get => _connection; }

        public abstract IDbDataAdapter Adapter(IDbCommand command);
        public abstract IDbDataAdapter Adapter(string sqlString);
        public abstract IDbCommand Command(string sqlString);

      

        public static string createCommandString(CmdType cmdType, string table, string[]? fields = null, string[] values = null)
        {
            string output = "";
            switch (cmdType)
            {
                case CmdType.Select: output = selectCommand(table, fields); break;
                case CmdType.Insert: output = insertCommand(table, fields, values); break;
                case CmdType.Update: output = updateCommand(table, fields, values); break;
                case CmdType.Delete: output = deleteCommand(table); break;
            }
            return output;
        }

        private static string selectCommand(string table, string[] fields)
        {
            string selectString = fields != null ? string.Join(",", fields) : "*";
            return String.Format("SELECT {0} FROM {1}", selectString, table);
        }

        private static string insertCommand(string table, string[] fields, string[] values)
        {
            if (values == null || fields == null || values.Length != fields.Length)
                return String.Empty;

            string fieldsString = String.Join(",", fields);
            string valueString = String.Join(",", values);

            return String.Format("INSERT INTO {0} ({1}) VALUES ({2})", table, fieldsString, valueString);
        }

        private static string updateCommand(string table, string[] fields, string[] values)
        {
            if (values == null || fields == null || fields.Length != values.Length)
                return String.Empty;

            string setString = String.Empty;
            string[] sets = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                sets[i] = $"{fields[i]} = {values[i]}";
            setString = String.Join(",", sets);

            return String.Format("UPDATE {0} SET ({1})", table, sets);
        }

        private static string deleteCommand(string table)
            => String.Format("DELETE FROM {0}", table);

        public static string JoinTables(JoinType join, string t1, string t2,  string p1, string p2)
        {

            return join switch
            {
                JoinType.Inner => $"{t1} INNER JOIN {t2} ON {p1} = {p2}",
                JoinType.Outer => $"{t1} OUTER JOIN {t2} ON {p1} = {p2}",
                JoinType.left => $"{t1} LEFT JOIN {t2} ON {p1} = {p2}",
                JoinType.right => $"{t1} RIGHT JOIN {t2} ON {p1} = {p2}",
                JoinType.leftOuter => $"{t1} LEFT OUTER JOIN {t2} ON {p1} = {p2}",
                JoinType.rightOuter => $"{t1} RIGHT OUTER JOIN {t2} ON {p1} = {p2}"
            };
        }

        public string Count(string table)
            => $"SELECT Count(ID) FROM {table}";

        public string Max(string table, string flied)
            => $"SELECT Max({flied}) FROM {table}";
    }
}
