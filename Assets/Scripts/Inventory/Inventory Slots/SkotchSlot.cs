using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkotchSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Skotch;
    }

    protected override bool IsUnlocked()
    {
        return SkotchItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!SkotchItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
