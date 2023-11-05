using UnityEngine;
using UnityEngine.UI;
public class SellButtonScript : MonoBehaviour
{
    public Text[] buttonTexts; // Массив компонентов Text кнопок
    public Settings_Oven[] settings; // Массив скриптов Settings_Oven

    // Метод, вызываемый при нажатии на кнопку продажи
    public void OnSellButtonClick()
    {
        float totalPrice = 0.0f;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            // Получаем стоимость из скрипта Settings_Oven, присоединенного к текущей кнопке
            int buttonCost = settings[i].cost;

            // Умножаем стоимость на количество текста кнопки
            float buttonPrice = buttonCost * float.Parse(buttonTexts[i].text);

            // Добавляем стоимость текущей кнопки к общей стоимости
            totalPrice += buttonPrice;

            // Обнуляем текст кнопки
            buttonTexts[i].text = "0";
        }

        Debug.Log("Total Price: " + totalPrice);
    }
}
