using NUnit.Framework;

namespace Tests
{
    public class CounterTests
    {
        private Counter _counter;
        private const float Tolerance = 0.0001f;

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
            Assert.AreEqual(1, _counter.Count, Tolerance);
        }

        [TestCase(10.5f)]
        [TestCase(20.2f)]
        [TestCase(30.7f)]
        public void ShouldIncrementCounterByParticularValue(float value)
        {
            Assert.Zero(_counter.Count);
            _counter.IncrementBy(value);
            Assert.AreEqual(value, _counter.Count, Tolerance);
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