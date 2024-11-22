using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RulerObject : MonoBehaviour
{
    public int RotaDirection = 1;
    public float baseRotation = RulerItem.SpawnRotation;
    public float lifetime = RulerItem.TimeAlive;
    private Rigidbody2D rulerRb;
    private BoxCollider2D rulerCollider;

    bool firstCollision = true;
    [SerializeField] PhysicsMaterial2D bounceMaterial;

    void Start()
    {
        rulerRb = GetComponent<Rigidbody2D>();
        rulerCollider = GetComponent<BoxCollider2D>();
        //definir position par rapport au transform du joueur
        gameObject.transform.rotation = Quaternion.Euler(0, 0, baseRotation * RotaDirection);
    }

    void Update()
    {
        if (rulerRb.velocity.magnitude < 0.001f)
        {
            StartCoroutine(DeleteRuler());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCollision)
        {
            firstCollision = false;
            rulerCollider.sharedMaterial = bounceMaterial;
            Debug.Log("boing");
        }
    }

    IEnumerator DeleteRuler()
    {
        rulerRb.isKinematic = true;
        yield return new WaitForSeconds(RulerItem.TimeAlive);
        Destroy(gameObject);
    }
}
