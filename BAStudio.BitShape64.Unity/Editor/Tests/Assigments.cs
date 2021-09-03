using BAStudio.BitShape64;
using NUnit.Framework;

public class Assigment
{
    [Test]
    public void Simple()
    {
        BitShape64 shape1 = new BitShape64(1, 1, 1); // w = 1, y = 1, the only cell set
        Assert.IsTrue(shape1.IsSet(0, 0));
        
        shape1 = new BitShape64(1, 1, 0);
        Assert.IsFalse(shape1.IsSet(0, 0));

        shape1.Set(0, 0, true);
        Assert.IsTrue(shape1.IsSet(0, 0));
    }

    [Test]
    public void Block()
    {
        BitShape64 shape1 = new BitShape64(5, 1, 0); // w = 1, y = 1, the only cell set
        for (int i = 0; i < 5; i++)
            Assert.IsFalse(shape1.IsSet(i, 0));
        
        shape1.Set(0, 0, 5, 1, true);

        for (int i = 0; i < 5; i++)
            Assert.IsTrue(shape1.IsSet(i, 0));
    }
}
