using System;
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
   

    private bool canUpgradeWood = false;
    private bool canUpgradeStone = false;
    private bool canUpgradeIron = false;
    private bool canUpgradeGold = false;
    private bool canUpgradeDiamond = false;

    public GameObject ButtonBuy;
   
    

   

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
            CostStoneText.text = Costs[1] + "$";
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
            CostIronText.text = Costs[2] + "$";
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
            CostGoldText.text = Costs[3] + "$";
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
            CostDaimondText.text = Costs[4] + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
        }
    }
    private void Update()
    {
        ScoreText.text = Convert.ToString(Score);

        // Проверяем, хватает ли денег для апгрейда дерева
        canUpgradeWood = (Score >= Costs[0]);
        canUpgradeStone = (Score >= Costs[1]);
        canUpgradeIron = (Score >= Costs[2]);
        canUpgradeGold = (Score >= Costs[3]);
        canUpgradeDiamond = (Score >= Costs[4]);

        // Обновляем спрайт кнопки деревянка в зависимости от условия
        if (canUpgradeWood)
        {
            Button woodButton = CostWoodText.GetComponentInParent<Button>();
            Image woodButtonImage = woodButton.GetComponent<Image>();
            woodButtonImage.sprite = Resources.Load<Sprite>("button_wood");
        }
        else
        {
            Button woodButton = CostWoodText.GetComponentInParent<Button>();
            Image woodButtonImage = woodButton.GetComponent<Image>();
            woodButtonImage.sprite = Resources.Load<Sprite>("Button_woodNO");
        }
        // Обновляем спрайт кнопки камень в зависимости от условия
        if (canUpgradeStone)
        {
            Button stoneButton = CostStoneText.GetComponentInParent<Button>();
            Image stoneButtonImage = stoneButton.GetComponent<Image>();
            stoneButtonImage.sprite = Resources.Load<Sprite>("button_stone");
        }
        else
        {
            Button stoneButton = CostStoneText.GetComponentInParent<Button>();
            Image stoneButtonImage = stoneButton.GetComponent<Image>();
            stoneButtonImage.sprite = Resources.Load<Sprite>("Button_stoneNO");
        }
        // Обновляем спрайт кнопки железо в зависимости от условия
        if (canUpgradeIron)
        {
            Button IronButton = CostIronText.GetComponentInParent<Button>();
            Image IronButtonImage = IronButton.GetComponent<Image>();
            IronButtonImage.sprite = Resources.Load<Sprite>("button_iron");
        }
        else
        {
            Button IronButton = CostIronText.GetComponentInParent<Button>();
            Image IronButtonImage = IronButton.GetComponent<Image>();
            IronButtonImage.sprite = Resources.Load<Sprite>("Button_ironNO");
        }

        // Обновляем спрайт кнопки голда в зависимости от условия
        if (canUpgradeGold)
        {
            Button GoldButton = CostGoldText.GetComponentInParent<Button>();
            Image GoldButtonImage = GoldButton.GetComponent<Image>();
            GoldButtonImage.sprite = Resources.Load<Sprite>("button_gold");
        }
        else
        {
            Button GoldButton = CostGoldText.GetComponentInParent<Button>();
            Image GoldButtonImage = GoldButton.GetComponent<Image>();
            GoldButtonImage.sprite = Resources.Load<Sprite>("Button_goldNO");
        }

        // Обновляем спрайт кнопки алмазик в зависимости от условия
        if (canUpgradeDiamond)
        {
            Button DiamondButton = CostDaimondText.GetComponentInParent<Button>();
            Image DiamondButtonImage = DiamondButton.GetComponent<Image>();
            DiamondButtonImage.sprite = Resources.Load<Sprite>("button_diamond");
        }
        else
        {
            Button DiamondButton = CostDaimondText.GetComponentInParent<Button>();
            Image DiamondButtonImage = DiamondButton.GetComponent<Image>();
            DiamondButtonImage.sprite = Resources.Load<Sprite>("Button_diamondNO");
        }

    }

}
