using System;
using UnityEngine;
using UnityEngine.UI;
public class SellButtonScript : MonoBehaviour
{
    public Text[] buttonTexts; 
    public Settings_Oven[] settings;     
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
        
        Game GameObj = FindObjectOfType<Game>();
        GameObj.add_score(Convert.ToInt32(totalPrice));

        Debug.Log("Total Price: " + totalPrice);
    }
}
