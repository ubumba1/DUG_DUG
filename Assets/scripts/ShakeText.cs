using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeText : MonoBehaviour
{
    public Text textComponent;
    public float shakeAmount = 1f;
    public float shakeDuration = 0.1f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = textComponent.transform.position;
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float offsetX = UnityEngine.Random.Range(-shakeAmount, shakeAmount);
            float offsetY = UnityEngine.Random.Range(-shakeAmount, shakeAmount);

            Vector3 newPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);
            textComponent.transform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textComponent.transform.position = originalPosition; 
    }
}
