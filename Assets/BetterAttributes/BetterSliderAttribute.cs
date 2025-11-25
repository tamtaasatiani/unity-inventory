using UnityEngine;

namespace BetterAttributes
{
    public class BetterSliderAttribute : PropertyAttribute
    {
        public readonly int Min;
        public readonly int Max;

        public BetterSliderAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
