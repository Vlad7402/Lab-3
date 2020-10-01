using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int FirstNum, SecNum, Step;
                Console.WriteLine("Введите начальное число");
                int.TryParse(Console.ReadLine(), out FirstNum);
                Console.WriteLine("Введите кончное число");
                int.TryParse(Console.ReadLine(), out SecNum);
                Console.WriteLine("Введите шаг построения");
                int.TryParse(Console.ReadLine(), out Step);
                if (SecNum - FirstNum > 0 && Step > 0)
                {
                    int[] ArrX = GetX(FirstNum, SecNum, Step);
                    int[] ArrY = GetY(ArrX);
                    TablePrint(ArrX, ArrY);
                    break;
                }
                else Console.WriteLine("Ошибка вваода");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static int[] GetX(int FirstNum,int SecNum,int Step)
        {
            int Lengh = (SecNum - FirstNum) / Step;
            int[] Result = Enumerable.Repeat(0, Lengh + 1).ToArray();
            int y = 0;
            for (int i = FirstNum; i <= SecNum; i += Step)
            {
                Result[y] = i;
                y++;
            }
            return Result;
        }
        static int[] GetY(int[] ArrIn)
        {
            int[] Result = Enumerable.Repeat(0, ArrIn.Length).ToArray();
            for (int i = 0; i < ArrIn.Length;)
            {
                Result[i] = (ArrIn[i] * 3 + 2)* ArrIn[i] + 131;
                i++;
            }
            return Result;
        }
        static int MaxLooking(int[] ArrIn)
        {
            int Max = 0;
            for (int i = 0; i < ArrIn.Length;)
            {
                if (ArrIn[i] > Max)  Max = ArrIn[i];
                i++;
            }
            string MaxStr = Convert.ToString(Max);
            return MaxStr.Length;
        }
        static void TablePrint(int[] ArrX,int[] ArrY)
        {
            int MaxX = MaxLooking(ArrX);
            int MaxY = MaxLooking(ArrY);
            Console.Write("||.");
            Console.Write("x");
            for (int i = 0; i < MaxX; i++)
            {
                Console.Write(".");
            }
            Console.Write("||.");
            Console.Write("y");
            for (int i = 0; i < MaxY; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine("||");
            for (int i = 0; i < ArrX.Length;)
            {
                int LenghtX = GetNumLenght(ArrX[i]);
                int LenghtY = GetNumLenght(ArrY[i]);
                Console.Write("||.");
                Console.Write(ArrX[i]);
                for (int j = 0; j < MaxX - LenghtX+1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("||.");
                Console.Write(ArrY[i]);
                for (int j = 0; j < MaxY - LenghtY+1; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine("||");
                i++;
            }
        }
        static int GetNumLenght(int Num)
        {
            string NumStr = Convert.ToString(Num);
            return NumStr.Length;
        }
    }
}
