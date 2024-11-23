using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultSlot : BaseInventorySlot<CatapultItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Catapults;
    }
}
