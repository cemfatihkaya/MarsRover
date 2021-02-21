using NUnit.Framework;

namespace MarsRover.Tests
{
    public abstract class BaseTestFixture : TestFixture
    {
        /// <summary>
        /// VerifyMocks metodunu tetikleyen işlemi. TestFixture'da tanımlanan tüm mock nesnelerin Verify edilmesi hedeflenir.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            VerifyMocks();
        }

        /// <summary>
        ///  TestFixture'da tanımlanan tüm mock nesnelerin Verify edilmesini hedefleyen soyut metot.
        ///  Mock nesnelerin VerifyAll() metodunun çağrılması beklenir.
        /// </summary>
        protected abstract void VerifyMocks();
    }
}