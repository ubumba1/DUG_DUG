using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isMoved = false;
    private static ButtonMovement activeButton;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    public void MoveButton()
    {
        if (activeButton != null && activeButton != this)
        {
            activeButton.ResetPosition();
        }

        if (isMoved)
        {
            ResetPosition();
        }
        else
        {
            Vector3 newTargetPosition = new Vector3(-147, 200.6f, 0);
            transform.LeanMoveLocal(newTargetPosition, 0.5f).setEaseOutExpo();
            isMoved = true;
            activeButton = this;
        }
    }

    public void ResetPosition()
    {
        transform.LeanMoveLocal(initialPosition, 0.5f).setEaseInExpo();
        isMoved = false;
        activeButton = null;
    }
}

