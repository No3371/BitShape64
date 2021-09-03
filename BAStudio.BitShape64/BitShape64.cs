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

        public void Set (int x, int y, bool state)
        {
            ulong uValue = unchecked((ulong)(this.value - long.MinValue));
            ulong mask = (ulong) 1 << GetCellBitIndex(x, y);
            if (state)
                uValue |= mask;
            else
                uValue &= ~mask;

            this.value = unchecked((long)uValue + long.MinValue);
        }

        public void Set (int x, int y, int blockWidth, int blockHeight, bool state)
        {
            int leftX, rightX, topY, bottomY;
            leftX = x;
            rightX = x + blockWidth - 1;
            topY = y;
            bottomY = y + blockHeight - 1;
            
            ulong uValue = unchecked((ulong)(this.value - long.MinValue));
            for (int h = 0, i = 0; h < blockHeight; h++)
            {
                for (int w = 0; w < blockWidth; w++, i++)
                {
                    ulong mask = (ulong) 1 << i;
                    uValue |= mask;
                }
            }

            this.value = unchecked((long)uValue + long.MinValue);
        }

        public bool IsSet (int x, int y)
        {
            return (value & (1 << GetCellBitIndex(x, y))) > 0;
        }

        int GetCellBitIndex (int x, int y)
        {
            if (x >= width || y >= height) throw new System.ArgumentOutOfRangeException();

            return y * width + x;
        }
        
        // Does not care about dimension of the other shape.
        public void Intersect (BitShape64 other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other.value - long.MinValue));
            value = unchecked((long) (valueSelf & valueOther) + long.MinValue);
        }

        // Does not care about dimension of the other shape.
        public void Union (BitShape64 other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other.value - long.MinValue));
            value = unchecked((long) (valueSelf | valueOther) + long.MinValue);
        }

        // Does not care about dimension of the other shape.
        public void Subtract (BitShape64 other)
        {
            ulong valueSelf = unchecked((ulong)(value - long.MinValue));
            ulong valueOther = unchecked((ulong)(other.value - long.MinValue));
            value = unchecked((long) (valueSelf & ~valueOther) + long.MinValue);
        }
    }
}