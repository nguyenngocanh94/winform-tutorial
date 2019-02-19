using System.Collections.Generic;
using WindowsFormsApp1.Exceptions;

namespace WindowsFormsApp1.database
{
    public class ConnectionPool : Pool
    {
        static readonly int INITIAL_POOL_SIZE = 5;
        static readonly int MAX_POOL_SIZE = 20;

        readonly List<Connection> connectionPool; 
        #pragma warning disable 649
        readonly List<Connection> usedConnection;
        #pragma warning restore 649

        ConnectionPool(List<Connection> connectionPool)
        {
            this.connectionPool = connectionPool;
        }

        public static ConnectionPool init()
        {
            var temp = new List<Connection>();
            for (var i = 0; i < INITIAL_POOL_SIZE; i++) temp.Add(new Connection());

            return new ConnectionPool(temp);
        }

        public Connection getOne()
        {
            if (connectionPool.Count == 0)
            {
                if (usedConnection.Count < MAX_POOL_SIZE)
                    connectionPool.Add(new Connection());
                else
                    throw new LeakConnectionException();
            }
            
            Connection ctx = connectionPool[connectionPool.Count - 1];
            connectionPool.RemoveAt(connectionPool.Count - 1);
            usedConnection.Add(ctx);

            return ctx;
        }

        public bool releaseOne(Connection connection)
        {    
            connectionPool.Add(connection);
            return usedConnection.Remove(connection);
        }

        public void shutdown()
        {
            for (int i = 0; i < usedConnection.Count; i++)
            {
                releaseOne(usedConnection[i]);
            }

            foreach (Connection connection in connectionPool)
            {
                connection.close();
            }
            
            usedConnection.Clear();
            connectionPool.Clear();
        }
    }
}