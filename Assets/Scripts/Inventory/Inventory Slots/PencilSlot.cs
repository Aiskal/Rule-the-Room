using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Pencil;
    }

    protected override bool IsUnlocked()
    {
        return PencilItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!PencilItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
