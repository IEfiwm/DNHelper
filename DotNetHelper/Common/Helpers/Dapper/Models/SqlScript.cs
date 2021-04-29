using System.Data;

namespace Dapper.Helper
{
    public class SqlScript
    {
        public string Sql { get; private set; }

        public object Param { get; private set; }

        public CommandType CommandType { get; private set; }

        public SqlScript(string sql, object param = null, CommandType cmdType = CommandType.Text)
        {
            Sql = sql;
            Param = param;
            CommandType = cmdType;
        }
    }
}
