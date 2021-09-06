using System;

namespace NBackGame
{
    class Program
    {
        static int Stage = 5;
        static int currentRount = 0;
        static bool isRun = true;
        static void Main(string[] args)
        {
            
            Console.WriteLine("N Back Game을 시작합니다.");
            GameManager manager = new GameManager();
            manager.GameInit();
            Stage += manager.N;
            while (isRun)
            {
                currentRount++;
                bool user = manager.Answer();
                bool reader = manager.GetReader(user);
               
                if (!reader)
                {
                    currentRount = Stage;
                }
                isRun = Stage > currentRount;
               
            }
            Console.WriteLine("종료.");
        }
    }
}
