using System.Data;
using System.Threading;

namespace Dapper.Client
{
    public class SlimCommandDefinition
    {
        public string CommandText { get; }

        /// <summary>
        /// The parameters associated with the command
        /// </summary>
        public object Parameters { get; }

        /// <summary>
        /// The type of command that the command-text represents
        /// </summary>
        public CommandType? CommandType { get; }

        public CommandFlags Flags { get; }

        /// <summary>
        /// For asynchronous operations, the cancellation-token
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initialize the command definition
        /// </summary>
        /// <param name="commandText">The text for this command.</param>
        /// <param name="parameters">The parameters for this command.</param>
        /// <param name="commandType">The <see cref="CommandType"/> for this command.</param>
        /// <param name="flags">The behavior flags for this command.</param>
        /// <param name="cancellationToken">The cancellation token for this command.</param>
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
