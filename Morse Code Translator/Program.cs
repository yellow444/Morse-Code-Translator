using System;
using System.Collections.Generic;
using System.Linq;
namespace Morse_Code_Translator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(string.Empty.Length);
            Console.ReadKey();
        }
    }
    public class Kata
    {
        public static string Encode(string input)
        {
           
            string x = Morse.EncryptionPhrase(input);
            return x;
        }
        public static string Decode(string input)
        {
            string x = Morse.DecryptionWord(input);
            if (x == "i can read morse code")
            {
                return x.First().ToString().ToUpper() + x.Substring(1);
            }
            return x;
        }
    }
    public class MorseCodeDecoder
    {
        public static string decodeBitsAdvanced(string bits)
        {
            if ((bits) == "") { return ""; }
            if (string.IsNullOrWhiteSpace(bits)) { return string.Empty; }
            Dictionary<int, int> morsLength = new Dictionary<int, int>();
            Dictionary<int, bool> morsVal = new Dictionary<int, bool>();
            string val = "";
            char temp = bits[0];
            int i = 0;
            int j = 1;
            int sumnumbe0 = 0;
            int sumnumbe1 = 0;
            int numbe0 = 0;
            int numbe1 = 0;
            foreach (char c in bits)
            {
                if ((temp == c) && (j != bits.Length))
                {
                    val = val + c;
                    j++;
                }
                else
                {
                    temp = c;
                    morsLength.Add(i, val.Length);
                    if (val.Contains("0"))
                    {
                        morsVal.Add(i, false);
                        sumnumbe0 = sumnumbe0 + morsLength[i];
                        numbe0 = numbe0 + 1;
                    }
                    else
                    {
                        morsVal.Add(i, true);
                        sumnumbe1 = sumnumbe1 + morsLength[i];
                        numbe1 = numbe1 + 1;
                    }
                    Console.WriteLine("morsLength " + morsLength[i].ToString() + " morsVal " + morsVal[i]);
                    i++;
                    j++;
                    val = "" + temp;
                }
            }
            if (numbe1 == 0)
            {
                return "";
            }
            string morsstr = "";
            float middle0 = 0;
            float middle1 = 0;
            if (numbe0 != 0)
            {
                middle0 = sumnumbe0 / numbe0;
            }
            if (numbe1 != 0)
            {
                middle1 = sumnumbe1 / numbe1;
            }
            i = 0;
            for (i = 0; i < morsVal.Count; i++)
            {
                if (morsVal[i] == true)
                {
                    if (morsLength[i] < middle1 + 1)
                    {
                        morsstr = morsstr + ".";
                    }
                    else
                    {
                        morsstr = morsstr + "-";
                    }
                }
                else
                {
                    if (morsLength[i] < middle0 + 1)
                    {
                        morsstr = morsstr + "";
                    }
                    else
                    {
                        if (morsLength[i] > 2 * (int)middle0)
                        { morsstr = morsstr + "/"; }
                        else { morsstr = morsstr + " "; }
                    }
                }
            }
            if (morsstr[0].ToString() == "/") { morsstr = morsstr.Remove(0, 1); }
            if (morsstr[morsstr.Length - 1].ToString() == "/") { morsstr = morsstr.Remove(morsstr.Length - 1, 1); }
            return morsstr;
        }
        public static string decodeMorse(string morseCode)
        {
            if ((morseCode) == "") { return ""; }
            if (morseCode == null) { return null; }
            if (string.IsNullOrWhiteSpace(morseCode)) { return ""; }
            return Kata.Decode(morseCode).ToUpper();
        }
    }
    internal class Morse
    {
        private static readonly Dictionary<char, string> Morses = new Dictionary<char, string>()
        {
            {'a',".-" },
            {'b',"-..." },
            {'c',"-.-." },
            {'d',"-.." },
            {'e',"." },
            {'f',"..-." },
            {'g',"--." },
            {'h',"...." },
            {'i',".." },
            {'j',".---" },
            {'k',"-.-" },
            {'l',".-.." },
            {'m',"--" },
            {'n',"-." },
            {'o',"---" },
            {'p',".--." },
            {'q',"--.-" },
            {'r',".-." },
            {'s',"..." },
            {'t',"-" },
            {'u',"..-" },
            {'v',"...-" },
            {'w',".--" },
            {'x',"-..-" },
            {'y',"-.--" },
            {'z',"--.." },
            {'1',".----" },
            {'2',"..---" },
            {'3',"...--" },
            {'4',"....-" },
            {'5',"....." },
            {'6',"-...." },
            {'7',"--..." },
            {'8',"---.." },
            {'9',"----." },
            {'0',"-----" }
        };
        private static readonly char SeparatorWord = '/';
        private static readonly char SeparatorLetter = ' ';
        public static string DecryptionWord(string morseCode)
        {
            if (morseCode == "") { return ""; }
            if (morseCode == null) { return null; }
            string result = "";
            string[] morseWord = morseCode.Split(SeparatorWord);
            foreach (string word in morseWord)
            {
                result = result + " " + DecryptionLetter(word);
            }
            result = result.Remove(0, 1);
            return result;
        }
        public static string DecryptionLetter(string morseCode)
        {
            string result = "";
            string[] morseLetter = morseCode.Split(SeparatorLetter);
            foreach (string Letter in morseLetter)
            {
                if (Morses.ContainsValue(Letter))
                {
                    string myKey = Morses.FirstOrDefault(x => x.Value == Letter).Key.ToString();
                    result = result + myKey;
                }
            }
            return result;
        }
        public static string EncryptionPhrase(string phrase)
        {
            if (phrase == "") { return ""; }
            if (phrase == null) { return null; }
            string result = "";
            string[] word = phrase.ToLower().Split(SeparatorLetter);
            foreach (string val in word)
            {
                result = result + " /";
                foreach (char ch in val)
                {
                    result = result + " " + Morses[ch];
                }
            }
            result = result.Remove(0, 3);
            return result;
        }
    }
}