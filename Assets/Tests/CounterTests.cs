using NUnit.Framework;

namespace Tests
{
    public class CounterTests
    {
        private Counter _counter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _counter = new Counter();
        }

        [TearDown]
        public void TearDown()
        {
            _counter.Reset();
        }
        
        [Test]
        public void ShouldIncrementCounter()
        {
            Assert.Zero(_counter.Count);
            _counter.Increment();
            Assert.AreEqual(1, _counter.Count);
        }
        
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ShouldIncrementCounterByParticularValue(int value)
        {
            Assert.Zero(_counter.Count);
            _counter.IncrementBy(value);
            Assert.AreEqual(value, _counter.Count);
        }

        [Ignore("For reasons")]
        [Test]
        public void ShouldResetCounterTo0()
        {
            _counter.Increment();
            _counter.Reset();
            Assert.Zero(_counter.Count);
        }
    }
}