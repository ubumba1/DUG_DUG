using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] int Score;
    public int[] Costs = {100,1000,10000,100000,1000000};
    public Text CostWoodText;
    public Text CostStoneText;
    public Text CostIronText;
    public Text CostGoldText;
    public Text CostDaimondText;
    public Text ScoreText;
    public GameObject ShopPanel;
    [SerializeField] private int ClickScore = 1;

    public void OnClickGrassButton()
    {
        Score += ClickScore;
    }

    public void OnClickWoodUpgrade()
    {
        if (Score >= Costs[0])
        {
            Score -= Costs[0];
            Costs[0] *= 2;
            ClickScore += 2;
            CostWoodText.text = Costs[0] + "$";
        }
    }

    public void OnClickStoneUpgrade()
    {
        if (Score >= Costs[1])
        {
            Score -= Costs[1];
            Costs[1] *= 2;
            ClickScore += 50;
            CostStoneText.text = Costs[1] + "$";
        }
    }
    public void OnClickIronUpgrade()
    {
        if (Score >= Costs[2])
        {
            Score -= Costs[2];
            Costs[2] *= 2;
            ClickScore += 100;
            CostIronText.text = Costs[2] + "$";
        }
    }
    public void OnClickGoldUpgrade()
    {
        if (Score >= Costs[3])
        {
            Score -= Costs[3];
            Costs[3] *= 2;
            ClickScore += 5000;
            CostGoldText.text = Costs[3] + "$";
        }
    }
    public void OnClickDaimondUpgrade()
    {
        if (Score >= Costs[4])
        {
            Score -= Costs[4];
            Costs[4] *= 2;
            ClickScore += 100000;
            CostDaimondText.text = Costs[4] + "$";
        }
    }
    private void Update()
    {
        ScoreText.text = Score + "$";
    }

}
