using System;

namespace LocalizationHelper
{
    public class Range: IComparable<int>
    {
        public int? Start { get; set; }
        public int? End { get; set; }
        public string Text { get; set; }

        public Range(int? start, int? end, string text)
        {
            Start = start;
            End = end;
            Text = text;
        }

        public bool InRange(int value)
        {
            return (!Start.HasValue || value.CompareTo(Start.Value) >= 0) &&
                   (!End.HasValue || End.Value.CompareTo(value) >= 0);
        }

        public int CompareTo(int other)
        {
            if (InRange(other))
                return 0;
            if (Start == null)
            {
                return 1;
            }

            if (End == null)
            {
                return -1;
            }
            return Start > other ? -1 : 1;
        }
    }
}