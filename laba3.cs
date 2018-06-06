using System;
using System.Collections;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string SECRET_NUMBER = ""; // строка, в которой хранится задуманное число

            /* ГЕНЕРАЦИЯ ЗАДУМАННОГО ЧИСЛА [НАЧАЛО] */
            var r = new Random(); 
            string a;
            int index;
            for (int i = 0; i < 4; i++) 
            {
                do
                {
                    int x = r.Next() % 10; 
                    a = x.ToString(); 
                    index = SECRET_NUMBER.IndexOf(a); 
                } while (index != -1); 
                SECRET_NUMBER = String.Concat(SECRET_NUMBER, a);
            }
            /* ГЕНЕРАЦИЯ ЗАДУМАННОГО ЧИСЛА [КОНЕЦ] */

            /* ПРОЦЕСС ИГРЫ [НАЧАЛО] */
            int BULLS_NUMBER = 0; // переменная, для хранения количества 'быков'
            int COWS_NUMBER = 0; // переменная, для хранения количества 'коров'
            string THE_STEP; // строка, для хранения введенное игроком числа

            Console.WriteLine("Компьютер уже что - то задумал. Играем!");
            Console.WriteLine("Узнай, что задумано компьютером!\n");

            do
            {
                THE_STEP = Console.ReadLine();

                if (THE_STEP.Length != 4 || !Character_check(THE_STEP))
                {
                    Console.WriteLine("Ошибка! Ход состоит из четырёх цифр.");
                }
                else if (!Repeated_check(THE_STEP))
                {
                    Console.WriteLine("Ошибка! Цифры не должны повторятья.");
                }
                else 
                {
                    COWS_NUMBER = NumberOfCows(THE_STEP, SECRET_NUMBER); 
                    BULLS_NUMBER = NumberOfBulls(THE_STEP, SECRET_NUMBER); 

                    string STEP_RESULT = String.Format("{0} : {1} коров, {2} быков", THE_STEP, COWS_NUMBER, BULLS_NUMBER); 
                    Console.WriteLine(STEP_RESULT); 
                }

            } while (BULLS_NUMBER != 4); 

            Console.WriteLine("Мууу! Победа!");
            Console.ReadKey();
            /* ПРОЦЕСС ИГРЫ [КОНЕЦ] */
        }

        /* МЕТОДЫ ДЛЯ ПРОВЕРКИ ВВЕДЕННОГО ЧИСЛА [НАЧАЛО] */
        static bool Character_check(string ANSWER) // метод для проверки на цифры
        {
            int number; 
            bool result = Int32.TryParse(ANSWER, out number);
            return result;
        }

        static bool Repeated_check(string ANSWER) // метод для проверки числа, на повторяющиеся цифры
        {
            int rav = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        if (ANSWER[i] == ANSWER[j])
                        { 
                            rav++;
                        }
                    }
                }
            };

            if (rav != 0)
                return false;

            return true;
        }
        /* МЕТОДЫ ДЛЯ ПРОВЕРКИ ВВЕДЕННОГО ЧИСЛА [КОНЕЦ] */

        /* МЕТОДЫ ДЛЯ ОБРАБОТКИ РЕЗУЛЬТАТА ХОДА [НАЧАЛО] */
        static int NumberOfCows(string ANSWER, string SECRET) // метод для получения количества коров
        {
            int cow = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j != i)
                    {
                        if (ANSWER[i] == SECRET[j])
                        {
                            cow++;
                        }
                    }
                }
            }

            return cow;
        }

        static int NumberOfBulls(string ANSWER, string SECRET) // метод для получения количества быков
        {
            int bull = 0;
            for (int i = 0; i < 4; i++)
            {
                if (ANSWER[i] == SECRET[i])
                {
                    bull++;
                }
            }
            return bull;
        }
        /* МЕТОДЫ ДЛЯ ОБРАБОТКИ РЕЗУЛЬТАТА ХОДА [КОНЕЦ] */
    }

}
