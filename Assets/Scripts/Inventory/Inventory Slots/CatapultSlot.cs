using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Catapults;
    }
}
