using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSlot : BaseInventorySlot<PlaneItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Plane;
    }
}
