using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] ItemIdentifier m_item;
    [SerializeField] SpriteRenderer m_spriteRenderer;

    public float verticalMovementSpeed = 10000.0f;
    public float verticalMovementAmplitude = 0.1f;
    public float highlightDuration = 0.5f;
    public float highlightScaleAmount = 1.2f;
    public float highlightRotationAmount = 15.0f;

    private Vector3 initialPosition;
    private Vector3 initialScale;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;
        StartCoroutine(ItemAnimation());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator ItemAnimation()
    {
        StartCoroutine(VerticalMovement());

        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(HighlightMovement());
        }
    }
    IEnumerator VerticalMovement()
    {
        while (true)
        {
            float newY = initialPosition.y + Mathf.Sin(Time.time * verticalMovementSpeed) * verticalMovementAmplitude;
            transform.localPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
            yield return null;
        }
    }

    IEnumerator HighlightMovement()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < highlightDuration)
        {
            float progress = elapsedTime / highlightDuration;
            float scale = 1.0f + Mathf.Sin(progress * Mathf.PI) * (highlightScaleAmount - 1.0f);
            float rotation = Mathf.Sin(progress * 2 * Mathf.PI) * highlightRotationAmount; 

            transform.localScale = initialScale * scale;
            transform.localRotation = initialRotation * Quaternion.Euler(0, 0, rotation);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Rétablir l'état initial
        transform.localScale = initialScale;
        transform.localRotation = initialRotation;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ItemDrop touched");
        if (collision.gameObject.layer != 3) return;

        Debug.Log(m_item);

            switch (m_item)
            {
                case ItemIdentifier.None: break;
                case ItemIdentifier.Pencil: GameSettings.PencilItem.Unlock(); break;
                case ItemIdentifier.Eraser: GameSettings.EraserItem.Unlock(); break;
                case ItemIdentifier.Skotch: GameSettings.SkotchItem.Unlock(); break;
                case ItemIdentifier.Ruler: GameSettings.RulerItem.Unlock(); break;
            }
            Destroy(gameObject);
    }

}

