using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSlot : BaseInventorySlot<PencilItem>
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Pencil;
    }
}
