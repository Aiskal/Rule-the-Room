using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Hammer;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.HammerItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.HammerItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }
    public override void ItemClicked()
    {
        if (!GameSettings.HammerItem.IsUnlocked) return;

        base.ItemClicked();
    }

    protected override bool IsUnlocked()
    {
        return GameSettings.HammerItem.IsUnlocked;
    }
}
