using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlaySong
{
    [Test]
    public void SaveSong_intoDictionary()
    {
    var floatTime = 80.0f;
    Util util = new Util();
    Assert.AreEqual(util.FloatToTimeString(floatTime), "01:20:000");
    }
    
}
