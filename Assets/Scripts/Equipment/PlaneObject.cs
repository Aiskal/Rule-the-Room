using System.Collections;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{

    [SerializeField] GameObject killZone1, killZone2;
    int RotaDirection;
    private float speed;
    private float fadeSpeed;
    //Coroutine planeCoroutine=StartCoroutine(DestroyCoroutine());  
    private Rigidbody2D planeRb;
    private Transform m_transform;
    private Material m_material;
    


    // Start is called before the first frame update
    void Start()
    {
        planeRb = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_material = GetComponent<Renderer>().material;

        RotaDirection = -1;
        speed = 1.8f;
        fadeSpeed = PlaneItem.FadeTime;

        gameObject.SetActive(false);
        killZone1.SetActive(false); 
        killZone2.SetActive(false);

    }

    void Update()
    {
        m_transform.position += new Vector3(RotaDirection * speed * Time.deltaTime, 0, 0);
    }
    private void OnEnable()
    {
        RotaDirection = GameSettings.PlayerObject.GetComponent<PlayerMovement>().PlayerDirection;

        Vector3 currentScale = transform.localScale;
        if (RotaDirection == 1 && currentScale.x > 0) currentScale.x = -Mathf.Abs(currentScale.x);
        else if (RotaDirection != 1 && currentScale.x < 0) currentScale.x = Mathf.Abs(currentScale.x);
        transform.localScale = currentScale;

        killZone1.SetActive(true);
        killZone2.SetActive(true);
    }

    private void OnDisable()
    {
        GameSettings.PlaneItem.ReleaseItem();

        killZone1.SetActive(false);
        killZone2.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
        else if (collision.collider.CompareTag("KillZone"))
        {
            Debug.Log("KillZone");
            gameObject.SetActive(false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            StartCoroutine(DestroyCoroutine());
        }

    }


    IEnumerator DestroyCoroutine()
    {
        int i = 0;
        i++;
        if (m_material != null)
        {
           
            Color baseColor = m_material.color;
            float elapsedTime = 0f, time = PlaneItem.FadeTime;

            while (elapsedTime < time)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / time;
                m_material.color = Color.Lerp(baseColor, new Color(1, 1, 1, 0), progress);
                yield return null;
            }
        }
        GameSettings.PlayerObject.transform.SetParent(null);
        gameObject.SetActive(false);    
        m_material.color = Color.white;
    }
}
