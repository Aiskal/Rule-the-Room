using UnityEngine;
using UnityEngine.Events;

public class SkotchItem : MonoBehaviour, IItemBase
{
    [SerializeField] PlayerMovement playerMovement;
    WallJump wallJump;

    private void Awake()
    {
        playerMovement = GameSettings.PlayerObject.GetComponent<PlayerMovement>(); 
        wallJump = playerMovement.gameObject.AddComponent<WallJump>();
        
        //OnItemUnlocked = new();
        //OnItemEquiped = new();
        //OnItemUnEquip = new();
        
        UnequipItem();
    }
    private void OnEnable()
    {
        EquipItem();
        WeaponButton.OnDoAction.AddListener(UseItem);
    }

    private void OnDisable()
    {
        WeaponButton.OnDoAction.RemoveListener(UseItem);
    }
    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Skotch;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; }  = new();
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; }  = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();



    public string GetDescription()
    {
        return "Un petit rouleau de scotch presque vide, avec des morceaux de ruban découpés de travers. Fragile mais tenace, il sert à tout réparer, tout recoller." +
            " Pour le petit soldat, il devient le lien entre les rêves brisés et les espoirs reconstruits. Avec un bout de scotch, tout peut tenir," +
            " même un avion destiné à traverser les frontières invisibles de l’amour et de la séparation.";
    }

    public void EquipItem()
    {
        Debug.Log("Equip Scotch");
        gameObject.SetActive(true);
        wallJump.enabled = true;
    }

    public void UnequipItem()
    {
        Debug.Log("Unequip Scotch");
        gameObject.SetActive(false);
        wallJump.enabled = false;
    }

    public void UseItem()
    {
        Debug.Log("Use Scotch");

    }

    public void Unlock()
    {
        if (IsUnlocked)
        {
            return;
        }

        IsUnlocked = true;
        OnItemUnlocked.Invoke(Identity);
    }
}