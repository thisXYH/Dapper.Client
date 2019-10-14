using System.Data.Common;
using static Dapper.SqlMapper;

namespace Dapper.Client
{
    /// <summary>
    /// 对<see cref="GridReader"/>进行一个包装。
    /// </summary>
    public class GridReaderWapper
    {
        private GridReader _gridReader;
        private DbConnection _connection;

        internal GridReaderWapper(GridReader gridReader, DbConnection connection)
        {
            _gridReader = gridReader;
            _connection = connection;
        }
    }
}
