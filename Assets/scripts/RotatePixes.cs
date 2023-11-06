using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePixes : MonoBehaviour
{
    public LeanTweenType easeType = LeanTweenType.easeOutExpo;
    public float duration = 0.5f;
    public GameObject imageObject;

    private Vector3 originalRotation;

    void Start()
    {
        originalRotation = imageObject.transform.eulerAngles;
    }

    public void RotateImageOnClick()
    {
        
        LeanTween.rotateZ(imageObject, originalRotation.z - 25f, duration)
            .setEase(easeType)
            .setOnComplete(() =>
            {
               
                LeanTween.rotateZ(imageObject, originalRotation.z, duration)
                    .setEase(easeType);
            });
    }
}




