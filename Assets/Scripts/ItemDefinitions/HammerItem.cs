using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HammerItem : MonoBehaviour, IItemBase
{
    [SerializeField] Transform _pivot; 
    [SerializeField] Button[] buttons; 


    Collider2D hammerCollider;

    public ItemIdentifier Identity { get; set; } = ItemIdentifier.Hammer;
    public bool IsUnlocked { get; set; }
    public UnityEvent<ItemIdentifier> OnItemUnlocked { get; set; } = new(); 
    public UnityEvent<ItemIdentifier> OnItemEquiped { get; set; } = new();
    public UnityEvent<ItemIdentifier> OnItemUnEquip { get; set; } = new();

    bool action = false;
    private void Awake()
    {
        //OnItemUnlocked = new();
        //OnItemEquiped = new();
        //OnItemUnEquip = new();

        UnequipItem();
        hammerCollider = GetComponent<Collider2D>();
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
        return "Un marteau bricolé avec un crayon et une gomme, parfait pour briser des obstacles légers. Simple et ingénieux, il reflète la créativité de son jeune créateur.";
    }

    public void EquipItem()
    {
        Debug.Log("Equip Hammer");
        gameObject.SetActive(true);
        GameSettings.ActiveItem = this;

    }

    public void UnequipItem()
    {
        Debug.Log("Unequip Hammer");
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        Debug.Log("Use Hammer");
        if(!action)
        StartCoroutine(RotateCoroutine());
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

    void OnTriggerStay2D(Collider2D other)
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

    IEnumerator RotateCoroutine()
    {
        action = true;
        float elapsedTime = 0.0f;
        float rotationDuration = 1.1f;
        Quaternion initialRotation = _pivot.rotation;
        float angle = 600 * GameSettings.PlayerObject.GetComponent<PlayerMovement>().PlayerDirection;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, angle);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }

        // EaseInOutElastic rotation towards the offset angle
        while (elapsedTime < rotationDuration*0.6f)
        {
            float progress = elapsedTime / rotationDuration;
            float easedProgress = EasingFunctions.EaseOutBounce(progress);

            _pivot.rotation = Quaternion.Lerp(initialRotation, targetRotation, easedProgress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        hammerCollider.enabled = true;

        while (elapsedTime < rotationDuration)
        {
            float progress = elapsedTime / rotationDuration;
            float easedProgress = EasingFunctions.EaseOutBounce(progress);

            _pivot.rotation = Quaternion.Lerp(initialRotation, targetRotation, easedProgress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        hammerCollider.enabled = false;

        //transform.rotation = targetRotation;
        targetRotation = initialRotation * Quaternion.Euler(0, 0, angle);
        // Reset elapsed time for linear rotation back to the initial angle
        elapsedTime = 0.0f;

        // Linear rotation back to the initial angle
        while (elapsedTime < rotationDuration)
        {
            float progress = elapsedTime / rotationDuration;

            _pivot.rotation = Quaternion.Lerp(targetRotation, initialRotation, progress);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _pivot.rotation = initialRotation;
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
        action = false;
    }



public static class EasingFunctions
{
        public static float EaseInOutElastic(float t)
        {
            float c5 = (2 * Mathf.PI) / 4.5f;
            return t == 0
                ? 0
                : t == 1
                    ? 1
                    : t < 0.5f
                        ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                        : (Mathf.Pow(2, 20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;

        }

        public static float EaseOutBounce(float x)
        {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            if (x < 1 / d1)
            {
                return n1 * x * x;
            }
            else if (x < 2 / d1)
            {
                return n1 * (x -= 1.5f / d1) * x + 0.75f;
            }
            else if (x < 2.5 / d1)
            {
                return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            }
            else
            {
                return n1 * (x -= 2.625f / d1) * x + 0.984375f;
            }
        }

    }

}
