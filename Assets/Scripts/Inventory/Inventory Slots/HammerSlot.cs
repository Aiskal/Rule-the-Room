using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSlot : BaseInventorySlot<HammerItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Hammer;
    }
}
