using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Cipher
{
    class AffineCipher
    {
        public int _KEYA = 0;
        public int _KEYB = 0;
        public static int ModCount = 26;
        //public int aInverse = MultiplicativeInverse(_KEYA);
        static void Main(string[] args)
        {

            string message = "Screw up";

            int affineKey = 0;
            int _KEYA = 3;
            int _KEYB = 17;


            //bool Mode = false;

            Console.WriteLine("\n");
            Console.WriteLine("Alphabet");
            PrintAlphabet(_KEYA, _KEYB);
            Console.WriteLine("\n");

            // True = Encrypt
            // False = Decrypt
            //Console.WriteLine(Mode ? 
            //    ($"Encrypted Message: {AffineEncrypt(message, _KEYA, _KEYB)}") :
            //    ($"Decrypted Message: {AffineDecrypt(message, _KEYA, _KEYB)}"));
            Console.WriteLine("Original message: ");
            Console.WriteLine(message);
            Console.WriteLine("\n");
            Console.WriteLine("Decrypt");
            Console.WriteLine(AffineDecrypt(message, _KEYA, _KEYB));
            Console.WriteLine();
            Console.WriteLine("Encrypt");
            Console.WriteLine($"Key {_KEYA}");
            Console.WriteLine(AffineEncrypt(message, _KEYA, _KEYB));
        }


        /// <summary>
        /// This will convert the message to uppercase and then put it into Character a Array
        /// then Compute e(x) = (ax + b)(mod m) for every character in the message
        /// </summary>
        /// <param name="plainText">The Message</param>
        /// <param name="a">Multiplication Key</param>
        /// <param name="b">Additive shift Amount</param>
        /// <returns> the encrypted message</returns>
        public static string AffineEncrypt(string plainText, int a, int b)
        {
            string cipherText = "";
            char[] chars = plainText.ToUpper().ToCharArray();
            foreach (char c in chars)
            {
                int charIndex = Convert.ToInt32(c);
                if (charIndex >= 65 && charIndex <= 90)
                {
                    //int x = Convert.ToInt32(c - 65);
                    charIndex -= 65;
                    //cipherText += Convert.ToChar(((a * charIndex + b) % ModCount) + 65);
                    charIndex = (((a * charIndex + b) % ModCount) + 65);
                }
                cipherText += (char)charIndex;
            }
            //cipherText = cipherText.Replace("@", " ");
            return cipherText;
        }


        /// <summary>
        /// This function takes cipher text and decrypts it using the Affine Cipher,
        /// d(x) = aInverse * (e(x)  b)(mod m).
        /// </summary>
        /// <param name="cipherText">The message</param>
        /// <param name="a">Multiplication Key</param>
        /// <param name="b">Additive shift Amount</param>
        /// <returns>The decrypted message</returns>
        public static string AffineDecrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            // Get Multiplicative Inverse of a
            int aInverse = MultiplicativeInverse(a);
            Console.WriteLine($"Keys inverse pair: {aInverse}");

            // Put Cipher Text (all capitals) into Character Array
            char[] chars = cipherText.ToCharArray();

            // Computer d(x) = aInverse * (e(x)  b)(mod m)
            foreach (char c in chars)
            {
                int charIndex = Convert.ToInt32(c);
                if (charIndex >= 65 && charIndex <= 90)
                {
                    charIndex -= 65;
                    charIndex = (aInverse * (charIndex - b)) % ModCount;
                    if (charIndex < 0)
                        charIndex += 26;
                    charIndex += 65;
                }
                else if (charIndex >= 97 && charIndex <= 122)
                {
                    charIndex -= 97;
                    charIndex = (aInverse * (charIndex - b)) % ModCount;
                    if (charIndex < 0)
                        charIndex += 26;
                    charIndex += 97;
                }
                plainText += (char)charIndex;
            }
            return plainText;
        }


        /// <summary>
        /// This functions returns the multiplicative inverse of integer a mod 26.
        /// </summary>
        /// <param name="a">Multiplication Key</param>
        /// <returns>The multiplicative inverse of integer a mod 26</returns>
        public static int MultiplicativeInverse(int a)
        {
            for (int x = 0; x < 26; x++)
            {
                if ((a * x) % ModCount == 1)
                    return x;
            }

            throw new Exception("No multiplicative inverse found!");
        }


        /// <summary>
        /// Prints out a visual of what the alphabet will look like
        /// </summary>
        /// <param name="a">Multiplication Key</param>
        /// <param name="b">Additive shift Amount</param>
        public static void PrintAlphabet(int a, int b)
        {
            Console.WriteLine("Original Alphabet:");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(((char)('A' + i)) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Ceaser Alphabet:");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(((char)('A' + (a * i) % ModCount)) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Affine Alphavet:");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(((char)('A' + (a * i + b) % ModCount)) + " ");
            }

        }

        public static int AffineKeyBreak(int KEY)
        {
            _KEYA = KEY / 26;
            _KEYB = KEY % 26;
            return (keya keyb);
        }
    }
}
