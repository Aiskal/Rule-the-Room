using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSlot : BaseInventorySlot
{
    protected override void Start()
    {
        base.Start();
        Identifyer = ItemIdentifier.Hammer;
    }

    public override void ItemClicked()
    {
        if (!HammerItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
