using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    public Sprite[] sprites; // Массив спрайтов для кнопки
    private Button grassButton; // Ссылка на компонент кнопки
    private int clickCounter = 0; // Счетчик нажатий

    void Start()
    {
        grassButton = GetComponent<Button>(); // Получаем компонент кнопки
        grassButton.onClick.AddListener(OnClickButton); // Подписываемся на событие нажатия кнопки
        grassButton.image.sprite = sprites[0]; // Устанавливаем начальный спрайт
    }

    void OnClickButton()
    {
        clickCounter++;

        if (clickCounter % 4 == 0) // Проверяем, было ли нажато 4 раза
        {
            int currentSpriteIndex = clickCounter / 4; // Вычисляем индекс нового спрайта
            if (currentSpriteIndex >= sprites.Length) // Если вышли за пределы массива, начинаем сначала
            {
                currentSpriteIndex = 0;
                clickCounter = 0; // Сбрасываем счетчик
            }
            grassButton.image.sprite = sprites[currentSpriteIndex]; // Устанавливаем новый спрайт
        }
    }
}
