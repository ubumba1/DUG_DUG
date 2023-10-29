using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] int Score;

    public Text ScoreText;

    public void OnClickGrassButton()
    {
        Score++;

    }

    private void Update()
    {
        ScoreText.text = Score + "$";
    }

}
