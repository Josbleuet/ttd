using NUnit.Framework;

namespace Domain.Tests
{
    public class FifoServiceTests
    {
        private FifoService<int> fifoService;

        private readonly int firstInsertedItem = 1111;
        private readonly int secondInsertedItem = 2222;
        private readonly int thirdInsertedItem = 3333;

        [SetUp]
        public void Setup()
        {
            fifoService = new FifoService<int>();
        }

        [Test]
        public void WhenInstanced_IsEmpty()
        {
            Assert.That(fifoService.IsEmpty(), Is.True);
        }

        [Test]
        public void WhenAnItemIsEnqueued_IsNotEmpty()
        {
            fifoService.Enqueue(firstInsertedItem);

            Assert.That(fifoService.IsEmpty(), Is.False);
        }

        [Test]
        public void ContainsOneItem_WhenDequeued_ShouldDequeueItem()
        {
            fifoService.Enqueue(firstInsertedItem);

            fifoService.Dequeue();

            Assert.That(fifoService.IsEmpty(), Is.True);
        }

        [Test]
        public void ContainsOneItem_WhenDequeued_ShouldReturnTheItem()
        {
            fifoService.Enqueue(firstInsertedItem);

            var dequeuedItem = fifoService.Dequeue();

            Assert.That(dequeuedItem, Is.EqualTo(firstInsertedItem));
        }

        [Test]
        public void ContainsMultipleItems_WhenDequeued_ShouldReturnItemsFirstInFirstOutOrder()
        {
            fifoService.Enqueue(firstInsertedItem);
            fifoService.Enqueue(secondInsertedItem);
            fifoService.Enqueue(thirdInsertedItem);

            var firstDequeuedItem = fifoService.Dequeue();
            var secondDequeuedItem = fifoService.Dequeue();
            var thirdDequeuedItem = fifoService.Dequeue();

            Assert.That(firstDequeuedItem, Is.EqualTo(firstInsertedItem));
            Assert.That(secondDequeuedItem, Is.EqualTo(secondInsertedItem));
            Assert.That(thirdDequeuedItem, Is.EqualTo(thirdInsertedItem));
        }
    }
}