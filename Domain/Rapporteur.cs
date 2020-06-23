using System;

namespace Domain
{
    public class Rapporteur
    {
        public virtual bool EstPlein()
        {
            return false;
        }

        public virtual void Rapporter(string message)
        {
            throw new Exception("NOT IMPLEMENTED");
        }
    }
}