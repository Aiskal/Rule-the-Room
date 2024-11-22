using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerButton : ButtonBehaviour
{
    public static event Action<bool> OnMove;
    public static event Action OnStop;
    public static event Action OnJump;
    
    public void BS_GoDirection(bool isLeft)
    {
        OnMove?.Invoke(isLeft);
        Debug.Log("Déplacement " + (isLeft ? "à gauche" : "à droite"));
    }
    
    public void BS_StopMoving()
    {
        OnStop?.Invoke();
    }

    // Méthode pour le saut
    public void BS_Jump()
    {
        OnJump?.Invoke();
        Debug.Log("Saut déclenché !");
    }
}
