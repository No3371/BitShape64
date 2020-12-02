using UnityEngine;

namespace BAStudio.BitShape64
{
    public class BitShape64Property : PropertyAttribute
    {
        public int column, row;

        public BitShape64Property(int column, int row)
        {
            this.column = column;
            this.row = row;
        }
    }
}