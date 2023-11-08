using UnityEngine;
using UnityEngine.UI;

public class ToggleMuteButton : MonoBehaviour
{
    public Sprite soundOnSprite; 
    public Sprite soundOffSprite; 
    private bool isMuted = false;
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        if (isMuted)
        {
            buttonImage.sprite = soundOffSprite;
        }
        else
        {
            buttonImage.sprite = soundOnSprite;
        }
    }
}

