using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu2 : MonoBehaviour
{
    public Transform box;
    public CanvasGroup Back;

    private void OnEnable()
    {
        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialog()
    {
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(Complite);
    }

    void Complite()
    {
        gameObject.SetActive(false);
    }
}
