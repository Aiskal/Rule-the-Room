using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObject : MonoBehaviour
{
    private CircleCollider2D hammerCollider;
    void Awake()
    {
        hammerCollider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(HammerAttack());
    }

    

    void DetectColliders()
    {
        if (hammerCollider != null)
        {
            // Calcule la position et les dimensions globales du trigger
            Vector2 center = (Vector2)transform.position + hammerCollider.offset;
            float radius = hammerCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

            // Trouve tous les colliders dans la zone
            Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius);

            foreach (Collider2D other in colliders)
            {
                if (other.gameObject.CompareTag("Destroyable"))
                {
                    other.gameObject.tag = "Untagged";
                    Debug.Log("BAM");
                    Destroyable destroyable = other.gameObject.GetComponent<Destroyable>();
                    if (destroyable != null)
                    {
                        destroyable.DestroyObject();
                    }
                }
            }
        }
    }



    IEnumerator HammerAttack()
    {
        yield return new WaitForSeconds(0.5f);
        hammerCollider.enabled = true;
        Coroutine detect = StartCoroutine(DetectCollisionsCoroutine());
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(detect);
        hammerCollider.enabled = false;
    }

    IEnumerator DetectCollisionsCoroutine()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            DetectColliders();
        }
    }
}
