namespace WindowsFormsApp1.database
{
    public interface Pool
    {
        void shutdown();
        bool releaseOne(Connection connection);
        Connection getOne();
    }
}