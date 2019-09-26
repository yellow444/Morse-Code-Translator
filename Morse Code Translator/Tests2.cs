using NUnit.Framework;

namespace Morse_Code_Translator
{
    [TestFixture]
    public class Tests2
    {
        [Test]
        public void testSomething()
        {
            Assert.AreEqual("HEY JUDE", MorseCodeDecoder.decodeMorse(MorseCodeDecoder.decodeBitsAdvanced("0000000011011010011100000110000001111110100111110011111100000000000111011111111011111011111000000101100011111100000111110011101100000100000")));
        }

        [Test]
        public void testEmptyMessage()
        {
            Assert.AreEqual(null, MorseCodeDecoder.decodeMorse(MorseCodeDecoder.decodeBitsAdvanced(null)));
        }
    }
}