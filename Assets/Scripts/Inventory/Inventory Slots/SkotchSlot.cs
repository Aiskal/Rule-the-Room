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

    public override void ItemClicked()
    {
        if (!SkotchItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
