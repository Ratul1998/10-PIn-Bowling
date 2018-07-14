using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework;
[TestFixture]
public class ActionMasterTest{
    private ActionMaster a;
    private ActionMaster.Action endturn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    [SetUp]
    public void Setuo()
    {
        a = new ActionMaster();
    }
    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void T01OneStrikereturnsEndTurn()
    {
        
        Assert.AreEqual(endturn,a.Bowl(10));
    }
    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        
        Assert.AreEqual(tidy,a.Bowl(8));
    }
    [Test]
    public void T03Bowl28ReturnsEndTurn()
    {
        Assert.AreEqual(endturn,a.Bowl(2));
        Assert.AreEqual(tidy, a.Bowl(8));
    }
    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
        foreach (int roll in rolls)
        {
            a.Bowl(roll);
        }
        Assert.AreEqual(reset, a.Bowl(10));
    }
}
