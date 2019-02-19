namespace WindowsFormsApp1.IoC
{
    public interface Container
    {
        void Register<T>(T thing);
        T Resolve<T> (string type);
    }
}