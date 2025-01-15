using UnityEngine.Events;

public interface IItemBase
{
    public ItemIdentifier Identity { get; set; }
    public bool IsUnlocked { get; set; }


    private void Start()
    {
        UnequipItem();
    }


    public void Unlock();

    public void EquipItem();

    public void UseItem();

    public void UnequipItem()
    {

    }

    public string GetDescription();

#region EVENTS

    //public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; }
    //public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; }
    //public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; }

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




