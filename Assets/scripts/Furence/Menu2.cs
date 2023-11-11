using UnityEngine.UI;
using UnityEngine;

public class Menu2 : MonoBehaviour
{
    public Transform box;
    public Image blockerImage;

    public AudioSource audioSource;

    private bool isDialogOpen = false;
    private void Awake() {
        box.LeanMoveLocalY(-Screen.height*5, 0.01f).setEaseInExpo();
    }

    private void Start()
    {
        box.localPosition = new Vector2(0, -Screen.height);

        blockerImage.enabled = false;

        audioSource.enabled = false;
    }

    public void ShowDialog()
    {
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
        blockerImage.enabled = true; 
        isDialogOpen = true;

        audioSource.enabled = true;
    }

    public void CloseDialog()
    {
        box.LeanMoveLocalY(-Screen.height*20, 0.5f).setEaseInExpo();
        blockerImage.enabled = false; 
        isDialogOpen = false;
        audioSource.enabled = false;
    }
}
