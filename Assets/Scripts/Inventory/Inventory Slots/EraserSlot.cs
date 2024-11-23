using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserSlot : BaseInventorySlot<EraserItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Eraser;
    }
}
