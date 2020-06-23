namespace Domain
{
    public class GreetingService
    {
        public GreetingService()
        {
        }

        public string Great(int hourOfDay)
        {
            return hourOfDay >= 7 && hourOfDay <= 17 ? "Bonjour" : "Bonsoir";
        }
    }
}