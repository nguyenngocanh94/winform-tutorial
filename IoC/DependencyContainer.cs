using System.Collections;
using WindowsFormsApp1.database;
using WindowsFormsApp1.Exceptions;

namespace WindowsFormsApp1.IoC
{
    public class DependencyContainer : Container
    {
        static DependencyContainer Container;
        readonly ArrayList dependencies = new ArrayList();

        public static DependencyContainer getInstance()
        {
            if (Container == null)
            {
                Container = new DependencyContainer();
            }

            return Container;
        }
        
       
        
        public void Register<T>(T thing)
        {
            dependencies.Add(new Wrapper<T>(thing.GetType().ToString(), thing));
        }

        public T Resolve<T>(string type)
        {
            for (int i = 0; i < dependencies.Count; i++)
            {
                // cast generic Wrapper into specific wrapper
                var temp = dependencies[i] as Wrapper<Connection>;
                // OK
                temp.getChild();

                // not OK
                dependencies[i].getChild();
            }

            throw new DependencyNotFoundException();
        }
        
        private DependencyContainer()
        {
            
        }
    }
}