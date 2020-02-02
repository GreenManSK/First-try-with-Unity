using System.Collections.Generic;
using System.Linq;
using LocalizationHelper.Data;
using UnityEngine;

namespace LocalizationHelper
{   
    public class RangedTranslation : ITranslation
    {
        private readonly int _argNumber;
        private readonly Range[] _ranges;

        public RangedTranslation(int argNumber, IEnumerable<Variant> variants)
        {
            _argNumber = argNumber;
            _ranges = variants
                .Select(variant => new Range(
                    variant.lowerBound != null ? int.Parse(variant.lowerBound) : null as int?,
                    variant.upperBound != null ? int.Parse(variant.upperBound) : null as int?,
                    variant.text
                ))
                .OrderBy(r => r.Start)
                .ToArray();
        }

        public string Translate(params object[] arguments)
        {
            var index = (int) arguments[_argNumber];
            var range = BinarySearch(_ranges, index);

            if (range != null)
                return string.Format(range.Text, arguments);
            
            Debug.LogError("No range for provided argument");
            return string.Format(_ranges[0].Text, arguments);
        }

        private static Range BinarySearch(IReadOnlyList<Range> arr, int key)
        {
            var minNum = 0;
            var maxNum = arr.Count - 1;

            while (minNum <= maxNum) {
                var mid = (minNum + maxNum) / 2;
                var comp = arr[mid].CompareTo(key);
                if (comp == 0) {
                    return arr[mid];
                }

                if (comp < 0) {
                    maxNum = mid - 1;
                }else {
                    minNum = mid + 1;
                }
            }
            return null;
        }
    }
}