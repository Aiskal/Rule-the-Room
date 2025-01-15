using UnityEngine;

public class LegoObstacle : Destroyable
{
    [SerializeField] GameObject destroyedState;
    [SerializeField] Transform spawnPoint;

    public override void DestroyObject()
    {
        Instantiate(destroyedState, spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
