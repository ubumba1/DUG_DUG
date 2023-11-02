using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    [SerializeField] ulong Score;
    public ulong[] Costs = {100,1000,10000,100000,1000000};
    public Text CostWoodText;
    public Text CostStoneText;
    public Text CostIronText;
    public Text CostGoldText;
    public Text CostDaimondText;
    public Text ScoreText;
    public GameObject ShopPanel;
    public GameObject grass_block;
    public GameObject dirt_block;
    public GameObject stone_block;
    public GameObject cubblestone_block;
    public GameObject basalt_block;
    public GameObject deepslate_block;
    public GameObject coal;
    public GameObject gold_ore_block;

    [SerializeField] private ulong ClickScore = 1;
   

    public GameObject ButtonBuy;
   

    public void OnClickGrassButton()
    {
        Score += ClickScore;
    }

    private string ShowCost(ulong val)
    {
        string[] symbols = { "", "K", "M", "B", "T", "aa", "ab" };
        string res = "";

        int symbolIndex = 0;
        double valAsDouble = (double)val;

        while (valAsDouble >= 1000 && symbolIndex < symbols.Length)
        {
            valAsDouble /= 1000.0;
            symbolIndex++;
        }

        if (valAsDouble < 10)
        {
            res = $"{valAsDouble:F1}{symbols[symbolIndex]}";
        }
        else
        {
            res = $"{valAsDouble:F0}{symbols[symbolIndex]}";
        }

        return res;
    }
    public void OnClickWoodUpgrade()
    {
        if (Score >= Costs[0])
        {
            Score -= Costs[0];
            Costs[0] *= 2;
            ClickScore += 2;
            CostWoodText.text = ShowCost(Costs[0]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }

    public void OnClickStoneUpgrade()
    {
        if (Score >= Costs[1])
        {
            Score -= Costs[1];
            Costs[1] *= 2;
            ClickScore += 50;
            CostStoneText.text = ShowCost(Costs[1]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }
    public void OnClickIronUpgrade()
    {
        if (Score >= Costs[2])
        {
            Score -= Costs[2];
            Costs[2] *= 2;
            ClickScore += 100;
            CostIronText.text = ShowCost(Costs[2]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }
    public void OnClickGoldUpgrade()
    {
        if (Score >= Costs[3])
        {
            Score -= Costs[3];
            Costs[3] *= 2;
            ClickScore += 5000;
            CostGoldText.text = ShowCost(Costs[3]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }
    public void OnClickDaimondUpgrade()
    {
        if (Score >= Costs[4])
        {
            Score -= Costs[4];
            Costs[4] *= 2;
            ClickScore += 100000;
            CostDaimondText.text = ShowCost(Costs[4]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }
    
    private void Update()
        {
            ScoreText.text = ShowCost(Score);

            UpdateButton(CostWoodText, 0, "button_wood", "Button_woodNO");
            UpdateButton(CostStoneText, 1, "button_stone", "Button_stoneNO");
            UpdateButton(CostIronText, 2, "button_iron", "Button_ironNO");
            UpdateButton(CostGoldText, 3, "button_gold", "Button_goldNO");
            UpdateButton(CostDaimondText, 4, "button_diamond", "Button_diamondNO");
        }

    private void UpdateButton(Text costText, int index, string upgradeSpriteName, string noUpgradeSpriteName)
    {
        Button button = costText.GetComponentInParent<Button>();
        Image buttonImage = button.GetComponent<Image>();
        
        bool canUpgrade = (Score >= Costs[index]);

        if (canUpgrade)
        {
            buttonImage.sprite = Resources.Load<Sprite>(upgradeSpriteName);
        }
        else
        {
            buttonImage.sprite = Resources.Load<Sprite>(noUpgradeSpriteName);
        }
    }

}
