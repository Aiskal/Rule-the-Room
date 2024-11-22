using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemBase
{
    public static bool IsUnlocked { get; private set; } = false;


    
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





