using NUnit.Framework;

namespace TestGreet.Test
{
    [TestFixture]
    public class GreetHelloTests
    {
        private IGreetHello _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new GreetHello();
        }

        [Test]
        public void Should_Send_Me_Hello_By_Name()
        {
            var actual =_sut.Greet("Gino");
            Assert.AreEqual("Hello, Gino.", actual);
            Assert.Pass("Ho salutato");
        }

        [Test]
        public void Should_Send_Me_Hello_My_Friend()
        {
            var actual = _sut.Greet(null);
            Assert.AreEqual("Hello, my friend.", actual);
            Assert.Pass("Ho salutato uno sconosciuto");
        }

        [Test]

        public void Should_Send_Me_Hello_By_Uppercase()
        {
            var actual = _sut.Greet("IGOR");
            Assert.AreEqual("HELLO IGOR!", actual);
            Assert.Pass("Ho salutato calorosamente");
        }

        [Test]

        public void Should_Send_Me_Hello_By_Couple()
        {
            var actual = _sut.Greet("Oussama","Nicola");
            Assert.AreEqual("Hello, Oussama and Nicola.", actual);
            Assert.Pass("Ho salutato 2 persone");
        }

        [Test]
        public void Should_Send_Me_Hello_By_Names()
        {
            var actual = _sut.Greet("Oussama", "Nicola","Gino","Igor");
            Assert.AreEqual("Hello, Oussama, Nicola, Gino and Igor.", actual);
            Assert.Pass("Ho salutato molte persone");
        }

        [Test]
        public void Should_Send_Me_Hello_By_Names_Uppercase()
        {
            var actual = _sut.Greet("OUSSAMA", "Nicola", "Gino", "Igor");
            Assert.AreEqual("Hello, Nicola, Gino and Igor. AND HELLO OUSSAMA!", actual);
            Assert.Pass("Ho salutato varie persone e una calorosamente.");
        }

        [Test]

        public void Should_Conatins_Comma()
        {
            var actual = _sut.Greet("Oussama", "Nicola", "Gino, Igor");
            Assert.AreEqual("Hello, Oussama, Nicola, Gino and Igor.", actual);
            Assert.Pass("Ho salutato varie persone con comma.");
        }

        [Test]

        public void Should_Contains_CSV_Char()
        {
            var actual = _sut.Greet("Oussama", "Nicola", "\"Gino, Igor\"");
            Assert.AreEqual("Hello, Oussama, Nicola and Gino, Igor.", actual);
            Assert.Pass(@"Ho salutato varie persone con \.");
        }
    }
}