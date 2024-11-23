using System.Diagnostics;
using UnityEngine.Events;

public abstract class ItemBase
{
    public static ItemIdentifier identity;
    public static bool IsUnlocked { get; private set; } = false;

    
    public static void Unlock()
    {
        if (IsUnlocked)
        {
            return;
        }

        IsUnlocked = true;
        OnItemUnlocked.Invoke(identity);
    }

#region EVENTS

    public static UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new();
    public static UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public static UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();

#endregion

}



public enum ItemIdentifier
{
    None,
    Pencil,
    Eraser,
    Skotch,
    Ruler, 
    Hammer,
    Plane, 
    Catapults
}




