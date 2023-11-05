using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialImagePosition;
    private bool isMoved = false;
    private static ButtonMovement activeButton;
    public Text buttonText; 
    public Text imageText;
    public Image imageToMove;
    


    public bool IsMoved { get { return isMoved; } }


    void Start()
    {
        initialPosition = transform.localPosition;
        initialImagePosition = imageToMove.transform.localPosition;
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

            Vector3 newImageTargetPosition = new Vector3(305.8f, -85, 0);
            imageToMove.transform.LeanMoveLocal(newImageTargetPosition, 0.5f).setEaseOutExpo();

            isMoved = true;
            activeButton = this;

            
            if (int.Parse(buttonText.text) > 0)
            {
                FindObjectOfType<CountdownTimer>().StartTimer();
            }
        }
    }

    public void ResetPosition()
    {
        transform.LeanMoveLocal(initialPosition, 0.5f).setEaseInExpo();
        imageToMove.transform.LeanMoveLocal(initialImagePosition, 0.5f).setEaseInExpo();
        isMoved = false;
        activeButton = null;
    }

   
}
