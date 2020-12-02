using UnityEngine;

namespace BAStudio.BitShape64
{
    public class TestBitShape64 : MonoBehaviour
    {
        [BitShape64Property(8, 8)]
        public long testValue = 0;
    }
}