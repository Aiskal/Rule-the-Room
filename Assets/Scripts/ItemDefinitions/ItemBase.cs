using UnityEngine.Events;

public abstract class ItemBase
{
    public static ItemIdentifier identity;
    public static bool IsUnlocked { get; private set; } = false;

    public abstract string GetDescription();
    
    public static void Unlock()
    {
        if (IsUnlocked) return;

        IsUnlocked = true;
        OnItemUnlocked.Invoke();
    }

#region EVENTS

    public static UnityEvent OnItemUnlocked { get; set; } = new();
    public static UnityEvent OnItemUsed { get; set; } = new();

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




