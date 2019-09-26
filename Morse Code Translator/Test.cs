using NUnit.Framework;

namespace Morse_Code_Translator
{
    [TestFixture]
    public class KataTest
    {
        [Test]
        public void SimpleEncodeTest()
        {
            Assert.AreEqual(".. / -.-. .- -. / .-- .-. .. - . / .. -. / -- --- .-. ... . / -.-. --- -.. .",
              Kata.Encode("I can write in morse code"));
        }

        [Test]
        public void SimpleDecodeTest()
        {
            Assert.AreEqual("I can read morse code",
              Kata.Decode(".. / -.-. .- -. / .-. . .- -.. / -- --- .-. ... . / -.-. --- -.. ."));
        }
    }
}