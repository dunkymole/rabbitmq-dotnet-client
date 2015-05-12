using System;
using System.Collections.Generic;

namespace RabbitMQ.Client
{
    /// <summary>
    /// <see cref="ConnectionFactory"/> uses implementations of this interface
    /// to choose the next hostname to be tried when connecting to the server. 
    /// </summary>
    public interface IEndpointSelectionStrategy : IEnumerator<AmqpTcpEndpoint>
    {
        /// <summary>
        /// List of hostnames to select from.
        /// </summary>
        IList<AmqpTcpEndpoint> Endpoints
        {
            set;
        }
    }
}
