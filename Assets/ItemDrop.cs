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

        Debug.Log(m_item);

        switch (m_item)
        {
            case ItemIdentifier.None: break;
            case ItemIdentifier.Pencil: PencilItem.Unlock(); break;
            case ItemIdentifier.Eraser: EraserItem.Unlock(); break;
            case ItemIdentifier.Skotch: SkotchItem.Unlock(); break;
            case ItemIdentifier.Ruler: RulerItem.Unlock(); break;
        }
        Destroy(gameObject);
    }

}
