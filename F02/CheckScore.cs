using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F02
{
    public class CheckScore
    {
        private int minimumScore = 24;
        private int maximumScore = 40;
        
        public bool DidStudentPass(int score)
        {
            if (score < minimumScore || score > maximumScore) return false;
            return true;
        }
    }
}
