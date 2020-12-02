using UnityEngine;

namespace BAStudio.BitShape64
{
    public struct BitShape64
    {
        public int width, height;
        public long value;
        public BitShape64(int width, int height, long shape)
        {
            this.width = width;
            this.height = height;
            this.value = shape;
        }

        public void Set (int x, int y, int width, int height, bool state)
        {
            ulong uValue = unchecked((ulong)(this.value - long.MinValue));
            for (int h = 0, i = 0; h < height; h++)
            for (int w = 0; w < width; w++, i++)
            {
                ulong mask = (ulong) 1 << i;
                uValue |= mask;
            }
            this.value = unchecked((long)uValue + long.MinValue);
        }
        
        // Does not care about dimension of the other shape.
        public void Intersect (long other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other - long.MinValue));
            value = unchecked((long) (valueSelf & valueOther) + long.MinValue);
        }

        // Does not care about dimension of the other shape.
        public void Union (long other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other - long.MinValue));
            value = unchecked((long) (valueSelf | valueOther) + long.MinValue);
        }

        // Does not care about dimension of the other shape.
        public void Subtract (long other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other - long.MinValue));
            value = unchecked((long) (valueSelf & ~valueOther) + long.MinValue);
        }
    }
}