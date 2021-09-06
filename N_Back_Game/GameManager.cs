using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBackGame
{
    public class GameManager
    {
        public int N;
        public List<int> round;
        public int score = 0;
        NBackUtil util;
        Stopwatch stopWatch;
        public GameManager()
        {
            util = new NBackUtil();
            stopWatch = new Stopwatch();
        }
        public void GameInit()
        {
            Console.WriteLine("시작하기에 앞서 N을 입력해주세요.");
            Console.WriteLine("1 <= N");
            InputN();
            GameSetting();
        }
        void InputN()
        {
            string input = Console.ReadLine();
            bool insertN = int.TryParse(input, out N);
            if (!insertN)
            {
                Console.WriteLine("숫자를 입력해주세요.");
                InputN();
            }else if (N <1)
            {
                Console.WriteLine("1 이상의 숫자를 입력해주세요.");
                InputN();
            }
        }
        void GameSetting()
        {
            score = 0;
            round = new List<int>();
            Console.WriteLine("준비중입니다.");
            while (round.Count <= N)
            {
                GetRandoms();
            }
            Console.Clear();
            Console.WriteLine($"N:{N} 게임 준비가 완료되었습니다");
            
        }
        void PrintList()
        {
            for (int i = 0; i < round.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write($"|{round[i]}|");
                }
                else
                {
                    Console.Write($"{round[i]}|");
                }
            }
            Console.Write($"\n");
        }
        void GetRandoms()
        {
            int ran = util.GetRandom(1, N+2);
            round.Add(ran);
        }
        public bool Answer()
        {
            GetRandoms();
            PrintList();
            int c_round = round[round.Count - 1];
            
            stopWatch.Restart();
            Console.WriteLine($"{c_round} 와 N Back 은 같습니까? (Y|N) ");
            string answer = Console.ReadLine();
            answer = answer.ToLower();
            bool yourAnswer = false;
            switch (answer)
            {
                case "y":
                    yourAnswer = true;
                    break;
                case "yes":
                    yourAnswer = true;
                    break;
                case "n":
                    yourAnswer = false;
                    break;
                case "no":
                    yourAnswer = false;
                    break;
            }
            stopWatch.Stop();
        
            return yourAnswer;
        }
        public bool GetReader(bool yourAnswer)
        {
            bool gameReader = Reader();
            bool result = yourAnswer == gameReader;
            TimeSpan time = stopWatch.Elapsed;
            double t = time.TotalSeconds;
            int getScore = Score((float)t);
            score += getScore;
            if (result)
            {
                Console.WriteLine($"정답입니다.[+{getScore}]");
            }
            else
            {
                Console.WriteLine($"틀렸습니다.[{score}]");
            }
            return result;
        }
        bool Reader()
        {
            int c_Rount = round[round.Count - 1];
            int n_Rount = round[round.Count - (N+1)];
            bool result = false;
            if (n_Rount == c_Rount)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        int Score(float useTime)
        {
            useTime = Math.Clamp(useTime, 1, 10);
            float delta = 1f - (useTime / 10f);
            int result = (int)(100f * delta);
            return result;
        }
        
    }
}
