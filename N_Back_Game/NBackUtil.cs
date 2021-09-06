using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBackGame
{
    public class NBackUtil
    {
        public int GetRandom(int min, int max)
        {
            Random ran = new Random();
            return ran.Next(min, max);
        }
        
    }
}
