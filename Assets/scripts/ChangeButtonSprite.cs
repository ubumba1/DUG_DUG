using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float backgroundMoveAmount = 1; 

    private Button grassButton;
    private int clickCounter = 0;

    
    public moveBackground backgroundMover;

    void Start()
    {
        grassButton = GetComponent<Button>();
        grassButton.onClick.AddListener(OnClickButton);
        grassButton.image.sprite = sprites[0];
    }

    void OnClickButton()
    {
        clickCounter++;

        if (clickCounter % 4 == 0)
        {
            int currentSpriteIndex = clickCounter / 4;
            if (currentSpriteIndex >= sprites.Length)
            {
                currentSpriteIndex = 0;
                clickCounter = 0;
            }
            grassButton.image.sprite = sprites[currentSpriteIndex];

            
            backgroundMover.RaiseBackground(backgroundMoveAmount);
        }
    }
}
