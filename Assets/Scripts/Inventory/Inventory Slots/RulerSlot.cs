using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerSlot : BaseInventorySlot<RulerItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Ruler;
    }
}
