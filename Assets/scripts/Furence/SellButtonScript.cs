using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class SellButtonScript : MonoBehaviour
{
    public Text[] buttonTexts; 
    public Settings_Oven[] settings;
    public ParticleSystem particleSystemPrefab;
    private bool isPlaying = false;
    public void OnSellButtonClick()
    {
        float totalPrice = 0.0f;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
             int buttonCost = settings[i].cost;

            float buttonPrice = buttonCost * float.Parse(buttonTexts[i].text);

            totalPrice += buttonPrice;

            buttonTexts[i].text = "0";
        }
        if (!isPlaying)
        {
            ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            newParticleSystem.Play();
            Destroy(newParticleSystem.gameObject, newParticleSystem.main.duration);
            isPlaying = true;
            StartCoroutine(ResetIsPlaying());
        }

        Game GameObj = FindObjectOfType<Game>();
        GameObj.add_score(Convert.ToInt32(totalPrice));

        Debug.Log("Total Price: " + totalPrice);
    }

    private IEnumerator ResetIsPlaying()
    {
        yield return new WaitForSeconds(particleSystemPrefab.main.duration);
        isPlaying = false;
    }
}
