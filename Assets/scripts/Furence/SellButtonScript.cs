using UnityEngine;
using UnityEngine.UI;
public class SellButtonScript : MonoBehaviour
{
    public Text[] buttonTexts; // ������ ����������� Text ������
    public Settings_Oven[] settings; // ������ �������� Settings_Oven

    // �����, ���������� ��� ������� �� ������ �������
    public void OnSellButtonClick()
    {
        float totalPrice = 0.0f;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            // �������� ��������� �� ������� Settings_Oven, ��������������� � ������� ������
            int buttonCost = settings[i].cost;

            // �������� ��������� �� ���������� ������ ������
            float buttonPrice = buttonCost * float.Parse(buttonTexts[i].text);

            // ��������� ��������� ������� ������ � ����� ���������
            totalPrice += buttonPrice;

            // �������� ����� ������
            buttonTexts[i].text = "0";
        }

        Debug.Log("Total Price: " + totalPrice);
    }
}
