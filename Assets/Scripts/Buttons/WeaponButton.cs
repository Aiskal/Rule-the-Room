using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : ButtonBehaviour
{
    public static event Action OnDoAction;
    public void BS_DoAction()
    {
        OnDoAction?.Invoke();
        Debug.Log("Action exécutée !");
    }
}
