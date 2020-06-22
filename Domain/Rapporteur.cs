using System;

namespace Domain
{
    public class Rapporteur
    {
        public bool EstPlein()
        {
            return false;
        }

        public virtual void Rapporter(String message)
        {
            throw new Exception("NOT IMPLEMENTED");
        }
    }
}