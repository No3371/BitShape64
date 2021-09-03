using System.Collections;
using System.Collections.Generic;
using BAStudio.BitShape64;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Intersection
{
    // A Test behaves as an ordinary method
    [Test]
    public void IntersectsSingleCell()
    {
        BitShape64 shape1 = new BitShape64(1, 1, 1); // w = 1, y = 1, the only cell set
        BitShape64 shape2 = new BitShape64(1, 1, 1); // w = 1, y = 1, the only cell set
        shape1.Intersect(shape2); 
        Assert.IsTrue(shape1.value == 1);
        shape1.Set(0, 0, false);
        shape1.Intersect(shape2);
        Assert.IsFalse(shape1.IsSet(0, 0));

    }

    // A Test behaves as an ordinary method
    [Test]
    public void Intersectsx2x2()
    {
        BitShape64 shape1 = new BitShape64(2, 2, 0); // w = 2, y = 2, none set
        BitShape64 shape2 = new BitShape64(2, 2, 0); // w = 2, y = 2, none set
        shape1.Intersect(shape2); 
        Assert.IsTrue(shape1.value == 0);
        
        shape1.Set(0, 0, true);
        shape2.Set(0, 0, true);
        shape1.Intersect(shape2); 
        Assert.IsTrue(shape1.IsSet(0, 0));
    }

    // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator IntersectsWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}
