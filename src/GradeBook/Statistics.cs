using System;

namespace GradeBook
{
    public class Statistics {
        public double Average = 0.0;
        public double Highest = 0.0;
        public double Lowest = 0.0;
        public char Letter = ' ';

        public Statistics(double Avg, double high, double low, char Letter) {
            this.Average = Avg;
            this.Highest = high;
            this.Lowest = low;
            this.Letter = Letter;
        }
    }
}