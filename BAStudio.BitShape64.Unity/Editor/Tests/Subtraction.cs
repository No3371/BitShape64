using BAStudio.BitShape64;
using NUnit.Framework;

public class Subtraction
{
    // A Test behaves as an ordinary method
    [Test]
    public void Subtract1x1()
    {
        BitShape64 shape1 = new BitShape64(1, 1, 1); // w = 1, y = 1, the only cell set
        BitShape64 shape2 = new BitShape64(1, 1, 1); // w = 1, y = 1, the only cell set

        shape1.Subtract(shape2);
        Assert.IsFalse(shape1.IsSet(0, 0));
    }
}