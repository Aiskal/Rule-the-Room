using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkotchSlot : BaseInventorySlot<SkotchItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Skotch;
    }
}