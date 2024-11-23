
using Unity.VisualScripting;
using UnityEngine;

public class SkotchEffect : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] GameObject skotchSprite;
    WallJump wallJump;

    private void Start()
    {
        wallJump = playerMovement.gameObject.AddComponent<WallJump>();
        UnequipSkotch();
        EquipSkotch();
    }


    private void OnEnable()
    {
        EraserItem.OnItemEquiped.AddListener(EquipSkotch);
        EraserItem.OnItemUnEquip.AddListener(UnequipSkotch);
    }

    private void OnDisable()
    {
        EraserItem.OnItemEquiped.RemoveListener(EquipSkotch);
        EraserItem.OnItemUnEquip.RemoveListener(UnequipSkotch);
    }

    void EquipSkotch()
    {
        skotchSprite.SetActive(true);
        wallJump.enabled = true;
    }

    void UnequipSkotch()
    {
        skotchSprite.SetActive(false);
        wallJump.enabled = false;
    }
}
