using UnityEngine;

/// <summary>
/// Simple classe encadrant la création et gestion des Singletons dans le runtime d'Unity. 
/// </summary>
/// <typeparam name="T">Type du singleton</typeparam>
public class SingletonMB<T> : MonoBehaviour where T : SingletonMB<T>
{
    private static T instance;
    protected static bool Instantiated { get; private set; } = false;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                    Instantiated = true;
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            Debug.Log($"{typeof(T).Name} singleton component Loaded");
            instance = this as T;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instantiated = true;
    }

}
