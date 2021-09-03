namespace BAStudio.BitShape64
{
    public static class BitShape64Utility
    {
        // O -> Horizontal First
        // ↓
        public static int CalculateCells (BitShape64 shape) // Support up to 8x8
        {
            int cells = 0;
            for (int w = 0; w < shape.width; w++)
            for (int h = 0; h < shape.height; h++)
            {
                if ((shape.value & (1 << (h * shape.width + h))) > 0) cells++;
            }
            return cells;
        }
        // O -> Horizontal First
        // ↓
        public static int GetShapeCoords (int offsetX, int offsetY, BitShape64 shape, (int x, int y)[] grids)
        {
            int cells = 0;
            for (int i = 0; i < shape.height; i++)
            {
                for (int j = 0; j < shape.width; j++)
            {
                if ((shape.value & (1 << (i * shape.width + i))) == 0) continue;
                cells++;
                grids[cells] = (offsetX+j, offsetY+i);
            }
            }

            return cells;
            // x = 3, y =5, w = 1, h = 3
            // (3+0, 5+0)
            // (3+0, 5+1)
            // (3+0, 5+2)

            // x = 2, y =1, w = 3, h = 2
            // (2+0, 1+0), (2+1, 1+0), (2+2, 1+0)
            // (2+0, 1+1), (2+1, 1+1), (2+2, 1+1)
        }
        
        public static void Iterate (BitShape64 shape, System.Action<int, int, bool> callback)
        {
            ulong value = unchecked((ulong)(shape.value - long.MinValue));
            for (int h = 0, i = 0; h < shape.height; h++)
            for (int w = 0; w < shape.width; w++, i++)
            {
                ulong mask = (ulong) 1 << i;
                callback(w, h, (value & mask) > 0);
            }
        }

        public static void Transcribe (BitShape64 shape, bool[,] dest)
        {
            ulong value = unchecked((ulong)(shape.value - long.MinValue));
            for (int h = 0, i = 0; h < shape.height; h++)
            for (int w = 0; w < shape.width; w++, i++)
            {
                ulong mask = (ulong) 1 << i;
                dest[w, h] = (value & mask) > 0;
            }
        }
    }
}