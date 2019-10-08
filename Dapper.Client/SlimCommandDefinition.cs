using System.Data;
using System.Threading;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="CommandDefinition"/>的简化版，
    /// 其中缺少了一个属性<see cref="CommandDefinition.Transaction"/>
    /// 该属性通过封装的DbClient统一配置。
    /// </summary>
    public class SlimCommandDefinition
    {
        public string CommandText { get; }

        public object Parameters { get; }

        public CommandType? CommandType { get; }

        public CommandFlags Flags { get; }

        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// 超时时间，当属性值为null的时候，
        /// 套用<see cref="AbstractDbClient.DefaultReadTimeout"/> or <see cref="AbstractDbClient.DefaultWriteTimeout"/>
        /// 的值为超时时间。
        /// </summary>
        public int? CommandTimeout { get; }

        public SlimCommandDefinition(
            string commandText, object parameters = null,
            int? commandTimeout = null,
            CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            CommandText = commandText;
            Parameters = parameters;
            CommandTimeout = commandTimeout;
            CommandType = commandType;
            Flags = flags;
            CancellationToken = cancellationToken;
        }
    }
}
