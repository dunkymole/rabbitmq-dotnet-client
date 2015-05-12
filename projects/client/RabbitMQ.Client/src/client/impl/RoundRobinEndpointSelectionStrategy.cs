using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Client.Impl
{
    /// <summary>
    /// Hostname selection strategy that round robins over a list of hostnames.
    /// </summary>
    /// <see cref="IEndpointSelectionStrategy"/>
    public class RoundRobinEndpointSelectionStrategy : IEndpointSelectionStrategy
    {
        private IEnumerator<AmqpTcpEndpoint> m_enumerator;

        public RoundRobinEndpointSelectionStrategy(IList<AmqpTcpEndpoint> endpoints)
        {
            m_enumerator = endpoints.GetEnumerator();
        }

        AmqpTcpEndpoint IEnumerator<AmqpTcpEndpoint>.Current
        {
            get { return m_enumerator.Current; }
        }

        void IDisposable.Dispose()
        {
            m_enumerator.Dispose();
        }

        object System.Collections.IEnumerator.Current
        {
            get { return m_enumerator.Current; }
        }

        bool System.Collections.IEnumerator.MoveNext()
        {
            return m_enumerator.MoveNext();
        }

        void System.Collections.IEnumerator.Reset()
        {
            m_enumerator.Reset();
        }

        IList<AmqpTcpEndpoint> IEndpointSelectionStrategy.Endpoints
        {
            // TODO: we should be more defensive and use enumerator of
            //       the copy of the value
            set { m_enumerator = value.GetEnumerator(); }
        }
    }
}
