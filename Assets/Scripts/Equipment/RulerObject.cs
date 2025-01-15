using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RulerObject : MonoBehaviour
{
    int RotaDirection = 1;
    float baseRotation = -220;
    float lifetime = 6f;

    private Rigidbody2D rulerRb;
    private BoxCollider2D rulerCollider;

    bool firstCollision = true;
    bool stopped;
    [SerializeField] PhysicsMaterial2D bounceMaterial;

    public UnityEvent OnFinish { get; set; } = new();

    void Start()
    {
        rulerRb = GetComponent<Rigidbody2D>();
        rulerCollider = GetComponent<BoxCollider2D>();
        //definir position par rapport au transform du joueur
    }

    private void OnEnable()
    {
        RotaDirection = GameSettings.PlayerObject.GetComponent<PlayerMovement>().PlayerDirection;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, baseRotation * RotaDirection);
        if(rulerRb == null)
        {
            rulerRb = GetComponent<Rigidbody2D>();
        }
        rulerRb.isKinematic = false;
    }


    void Update()
    {
        if (rulerRb.velocity.magnitude < 0.01f && !stopped)
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
        stopped = true;
        yield return new WaitForSeconds(lifetime);

        // Désactiver le Rigidbody2D pour qu'il cesse d'interagir avec la physique
        if (rulerRb != null)
        {
            rulerRb.isKinematic = true;
        }
        
        // Après un certain temps de vie, désactiver l'objet
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        OnFinish.Invoke();
        stopped = false;


    }
}
