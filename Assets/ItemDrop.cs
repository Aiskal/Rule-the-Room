using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] ItemIdentifier m_item;
    [SerializeField] SpriteRenderer m_spriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("AAAAAAA");
        if (collision.gameObject.layer != 3) return;


        switch (m_item)
        {
            case ItemIdentifier.None: return;
            case ItemIdentifier.Eraser: EraserItem.Unlock(); return;
            case ItemIdentifier.Pencil: PencilItem.Unlock(); return;
            case ItemIdentifier.Skotch: SkotchItem.Unlock(); return;
            case ItemIdentifier.Ruler: RulerItem.Unlock(); return;

        }
        Destroy(gameObject);
    }

}
