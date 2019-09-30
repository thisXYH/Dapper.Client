using System.Data;
using System.Threading;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="CommandDefinition"/>的简化版，
    /// 其中缺少了两个属性<see cref="CommandDefinition.Transaction"/>,<see cref="CommandDefinition.CommandTimeout"/>。
    /// </summary>
    public class SlimCommandDefinition
    {
        public string CommandText { get; }

        public object Parameters { get; }

        public CommandType? CommandType { get; }

        public CommandFlags Flags { get; }

        public CancellationToken CancellationToken { get; }

        public SlimCommandDefinition(
            string commandText, object parameters = null,
            CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            CommandText = commandText;
            Parameters = parameters;
            CommandType = commandType;
            Flags = flags;
            CancellationToken = cancellationToken;
        }
    }
}
