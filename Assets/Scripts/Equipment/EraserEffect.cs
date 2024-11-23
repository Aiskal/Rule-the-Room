
using UnityEngine;

public class EraserEffect : MonoBehaviour
{
    [SerializeField] private ApplyMaterial eraserEffect;
    [SerializeField] GameObject eraserSprite;

    private void Start()
    {
        UnequipEraser(ItemIdentifier.Eraser);
    }


    private void OnEnable()
    {
        EraserItem.OnItemEquiped.AddListener(EquipEraser);
        EraserItem.OnItemUnEquip.AddListener(UnequipEraser);
    }

    private void OnDisable()
    {
        EraserItem.OnItemEquiped.RemoveListener(EquipEraser);
        EraserItem.OnItemUnEquip.RemoveListener(UnequipEraser);
    }

    void EquipEraser(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Eraser) return;

        eraserEffect.enabled = true;
        eraserSprite.SetActive(true);
    }

    void UnequipEraser(ItemIdentifier item)
    {
        if (item != ItemIdentifier.Eraser) return;

        eraserEffect.enabled = false;
        eraserSprite.SetActive(false);
    }
}
