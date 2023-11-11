using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float backgroundMoveAmount = 1; 
    int current_hp;
    int total_hp;
    int clickCounter;
    private Button grassButton;

    public void Start()
    {
        grassButton = GetComponent<Button>();
        grassButton.onClick.AddListener(OnClickButton);
        grassButton.image.sprite = sprites[0];
    }
    public void ResetSprite()
    {
        grassButton.image.sprite = sprites[0];
    }
    public void OnClickButton()
    {
        clickCounter++;
        Game GameObj = FindObjectOfType<Game>();
        current_hp = GameObj.Get_block_hp();
        total_hp = GameObj.Get_current_total_block_hp();

        float percent = current_hp / (float)total_hp * 100;
        Debug.Log("current_hp  " + current_hp + "| total_hp " + total_hp + "| percent " + percent);
        if (percent > 0 && percent <= 20)
        {
            grassButton.image.sprite = sprites[4];
        }
        else if (percent > 20 && percent <= 40)
        {
            grassButton.image.sprite = sprites[3];
        }
        else if (percent > 40 && percent <= 60)
        {
            grassButton.image.sprite = sprites[2];
        }
        else if (percent > 60 && percent <= 80)
        {
            grassButton.image.sprite = sprites[1];
        }
        else if (percent > 80 && percent <= 100)
        {
            grassButton.image.sprite = sprites[0];
        }

    }
}
