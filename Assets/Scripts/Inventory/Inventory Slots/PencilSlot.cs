using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilSlot : BaseInventorySlot
{
    protected override void Awake()
    {
        Identifyer = ItemIdentifier.Pencil;
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSettings.PencilItem.OnItemUnlocked.AddListener(UpdateButtonLock);
    }

    private void OnDisable()
    {
        GameSettings.PencilItem.OnItemUnlocked.RemoveListener(UpdateButtonLock);

    }

    protected override bool IsUnlocked()
    {
        return GameSettings.PencilItem.IsUnlocked;
    }

    public override void ItemClicked()
    {
        if (!GameSettings.PencilItem.IsUnlocked) return;

        base.ItemClicked();
    }
}
