using System;

namespace Domain
{
    public class RapporteurMock : Rapporteur
    {
        public bool EstPlein()
        {
            return false;
        }

        public override void Rapporter(String message)
        {
        }
    }
}
