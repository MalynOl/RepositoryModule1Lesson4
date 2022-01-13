using System;

namespace HomeWork4Repository
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            int n = 0;
            bool numberTrue = false;
            while (!numberTrue)
            {
                string nString = GetStr();
                numberTrue = int.TryParse(nString, out n);
            }

            int[] masNumbers = RandomMas(n);
            int countEvenNumbersInMas = 0;
            int countOddNumbersInMas = 0;
            CountEvenAndOddNumbers(masNumbers, ref countEvenNumbersInMas, ref countOddNumbersInMas);
            int[] masEvenNumbers = new int[countEvenNumbersInMas];
            int[] masOddNumbers = new int[countOddNumbersInMas];
            WriteToArrayNumbers(masNumbers, ref masEvenNumbers, ref masOddNumbers);
            const string strUpperLetters = "aeidhj";
            int countUpperLetterEvent = 0;
            int countLowerLetterOdd = 0;
            string[] masEvenLetters = WriteToArrayLetters(masEvenNumbers, strUpperLetters, ref countUpperLetterEvent);
            string[] masOddLetters = WriteToArrayLetters(masOddNumbers, strUpperLetters, ref countLowerLetterOdd);
            if (countUpperLetterEvent > countLowerLetterOdd)
            {
                Console.WriteLine("В массиве с четным номером букв больше букв в верхнем регистре");
            }
            else if (countUpperLetterEvent < countLowerLetterOdd)
            {
                Console.WriteLine("В массиве с нечетным номером букв больше букв в верхнем регистре");
            }
            else if (countUpperLetterEvent == 0 && countLowerLetterOdd == 0)
            {
                Console.WriteLine("Ни один из массивов не содержит букв в верхнем регистре!");
            }
            else
            {
                Console.WriteLine("В массивах одинаковое количество букв в верхнем регистре");
            }

            var strLetterEvent = string.Join(" ", masEvenLetters);
            var strLetterOdd = string.Join(" ", masOddLetters);
            Console.WriteLine("Массив с четным номером букв: " + strLetterEvent.ToString());
            Console.WriteLine("Массив с нечетным номером букв: " + strLetterOdd.ToString());
        }

        public static string GetStr()
        {
            Console.WriteLine("Введите размер массива и нажмите Enter");
            string nString = Console.ReadLine();

            return nString;
        }

        public static int[] RandomMas(int numberElements)
        {
            int[] mas = new int[numberElements];
            for (int i = 0; i < numberElements; i++)
            {
                mas[i] = new Random().Next(1, 26);
            }

            return mas;
        }

        public static void CountEvenAndOddNumbers(int[] inputMasNumbers, ref int countEvenNumbers, ref int countOddNumbers)
        {
            for (int i = 0; i < inputMasNumbers.Length; i++)
            {
                if (inputMasNumbers[i] % 2 == 0)
                {
                    countEvenNumbers++;
                }
                else
                {
                    countOddNumbers++;
                }
            }
        }

        public static void WriteToArrayNumbers(int[] mainMas, ref int[] goalMasEvenNumbers, ref int[] goalMasOddNumbers)
        {
            int j = 0, k = 0;
            for (int i = 0; i < mainMas.Length; i++)
            {
                if (mainMas[i] % 2 == 0 && j < goalMasEvenNumbers.Length)
                {
                    goalMasEvenNumbers[j] = mainMas[i];
                    j++;
                }
                else if (k < goalMasOddNumbers.Length)
                {
                    goalMasOddNumbers[k] = mainMas[i];
                    k++;
                }
            }
        }

        public static string[] WriteToArrayLetters(int[] masNumbers, string upperLetters, ref int countUpperLetter)
        {
            string[] masLetters = new string[masNumbers.Length];
            string letter = " ";
            for (int i = 0; i < masNumbers.Length; i++)
            {
                letter = ((EnglishLetters)masNumbers[i]).ToString();
                if (upperLetters.Contains(letter))
                {
                    masLetters[i] = letter;
                    countUpperLetter++;
                }
                else
                {
                    masLetters[i] = letter.ToLower();
                }
            }

            return masLetters;
        }
    }
}
