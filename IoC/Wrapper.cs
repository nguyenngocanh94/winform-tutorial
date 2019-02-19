using System;

namespace WindowsFormsApp1.IoC
{
    public class Wrapper<T>
    {
        public string name;
        public T child;

        public Wrapper(string name, T child)
        {
            this.name = name;
            this.child = child;
        }

        public string getName()
        {
            return name;
        }

        public T getChild()
        {
            return child;
        }
    }
}