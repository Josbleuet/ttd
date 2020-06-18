using NUnit.Framework;

namespace Domain.Tests
{
    public class GreetingServiceTests
    {
        private GreetingService greetingService;

        [SetUp]
        public void Setup()
        {
            greetingService = new GreetingService();
        }

        [Test]
        public void After7hSayBonjour()
        {
            Assert.That(greetingService.Great(8), Is.EqualTo("Bonjour"));
        }

        [Test]
        public void Before17hSayBonjour()
        {
            Assert.That(greetingService.Great(16), Is.EqualTo("Bonjour"));
        }

        [Test]
        public void At17hSayBonjour()
        {
            Assert.That(greetingService.Great(17), Is.EqualTo("Bonjour"));
        }

        [Test]
        public void At7hSayBonjour()
        {
            Assert.That(greetingService.Great(7), Is.EqualTo("Bonjour"));
        }

        [Test]
        public void After18hSayBonsoir()
        {
            Assert.That(greetingService.Great(19), Is.EqualTo("Bonsoir"));
        }

        [Test]
        public void At18hSayBonsoir()
        {
            Assert.That(greetingService.Great(18), Is.EqualTo("Bonsoir"));
        }

        [Test]
        public void Before6hSayBonsoir()
        {
            Assert.That(greetingService.Great(5), Is.EqualTo("Bonsoir"));
        }

        [Test]
        public void At6hSayBonsoir()
        {
            Assert.That(greetingService.Great(6), Is.EqualTo("Bonsoir"));
        }
    }
}