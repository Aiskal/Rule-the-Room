using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoObstacle : Destroyable
{
    public override void DestroyObject()
    {
        Destroy(gameObject);
    }

}
