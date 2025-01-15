using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Ruler;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.RulerItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.RulerItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }

    protected override bool IsUnlocked()
    {
        return GameSettings.RulerItem.IsUnlocked;
    }
    public override void ItemClicked()
    {
        if (!GameSettings.RulerItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
