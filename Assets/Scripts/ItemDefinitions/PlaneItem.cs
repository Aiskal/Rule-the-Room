using UnityEngine;
using UnityEngine.Events;

public class PlaneItem : MonoBehaviour,  IItemBase
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] PlaneObject plane;
    SpriteRenderer spriteRenderer;
    bool locked;
    public static float FlightSpeed { get; } = 0.3f;

    public static float FadeTime { get; } = 1f;

    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Plane;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();


    private void Awake()
    {
        //OnItemUnlocked = new();
        //OnItemEquiped = new();
        //OnItemUnEquip = new();

        UnequipItem();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    public string GetDescription()
    {
        return "Voici le redoutable Crayonojet 3000, le fleuron de l'aviation enfantine ! Avec un crayon comme fuselage," +
            " une règle ultra-aérodynamique pour les ailes et du scotch indestructible pour tout maintenir, cet avion est prêt à conquérir les cieux…" +
            " ou au moins à traverser la chambre. Attention, turbulences garanties si le vent du ventilateur se lève !";
    }

    public void EquipItem()
    {
        Debug.Log("Equip Plane");
        gameObject.SetActive(true);
        GameSettings.ActiveItem = this;



    }

    public void UnequipItem()
    {
        Debug.Log("Unquip Plane");
        gameObject.SetActive(false);

    }

    public void UseItem()
    {
        if (locked) return;
        Debug.Log("Use Plane");
        plane.transform.position = spawnPoint.position;
        plane.gameObject.SetActive(true);
        LockItem();
    }

    void LockItem()
    {
        locked = true;
        spriteRenderer.enabled = false;
    }
    public void ReleaseItem()
    {
        locked = false;
        spriteRenderer.enabled = true;
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
    