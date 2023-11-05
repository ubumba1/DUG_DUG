using UnityEngine.UI;
using UnityEngine;

public class Menu2 : MonoBehaviour
{
    public Transform box;
    public Image blockerImage; // Публичная переменная для блокировщика

    public AudioSource audioSource; // Ссылка на AudioSource

    private bool isDialogOpen = false;

    private void Start()
    {
        // Начинаем с картинки вне видимости экрана
        box.localPosition = new Vector2(0, -Screen.height);

        // При запуске сцены блокировщик выключен
        blockerImage.enabled = false;

        // В начале убедимся, что AudioSource выключен
        audioSource.enabled = false;
    }

    public void ShowDialog()
    {
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        blockerImage.enabled = true; // Включаем блокировщик
        isDialogOpen = true;

        // Включаем AudioSource
        audioSource.enabled = true;
    }

    public void CloseDialog()
    {
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        blockerImage.enabled = false; // Выключаем блокировщик
        isDialogOpen = false;

        // Выключаем AudioSource
        audioSource.enabled = false;
    }
}
