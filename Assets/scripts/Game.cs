using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class Game : MonoBehaviour
{
    [SerializeField] int Score;
    public int coalcost = 90;
    public Text coal_out;
    public int[] Costs = {100,1000,10000,100000,1000000};
    public Text CostWoodText;
    public Text CostStoneText;
    public Text CostIronText;
    public Text CostGoldText;
    public Text CostDaimondText;
    public Text ScoreText;
    public Text DamageText;
    public Text[] CountArray;
    public moveBackground backgroundMover;
   
    public GameObject coal;
    
    private SpawnButtons button_spawner;
    ChangeButtonSprite SpriteReseter;
    public int current_total_block_hp;
    [SerializeField] public int current_block_hp;
    [SerializeField] public string current_block_name;
    [SerializeField] private int ClickScore = 100;
    public GameObject ButtonBuy;


    public Image PixesImage;
    public Sprite stoneUpgradeSprite;
    public Sprite ironUpgradeSprite;
    public Sprite goldUpgradeSprite;
    public Sprite diamondUpgradeSprite;
    public Sprite woodUpgradeSprite;
    private Sprite currentSprite;


    private bool woodUpgradeApplied = false;
    private bool stoneUpgradeApplied = false;
    private bool ironUpgradeApplied = false;
    private bool goldUpgradeApplied = false;
    private bool diamondUpgradeApplied = false;

    public AudioSource blockDestroyedSound;
    public GameObject dirtPrefab; 
    public GameObject stonePrefab;
    public GameObject DeepPrefab;
    public GameObject IronPrefab;
    public GameObject GoldPrefab;
    public GameObject LazurPrefab;
    public GameObject RedsPrefab;
    public GameObject EmeraldPrefab;
    public GameObject DiamondPrefab;

    void Start()
    {
        ClickScore = 100;
        Transform randomTransform = GameObject.Find("Canvas/Random").transform;
        button_spawner = randomTransform.GetComponent<SpawnButtons>();

        (current_block_hp, current_block_name) = button_spawner.SpawnRandomButtons();
        current_total_block_hp = current_block_hp;
    }

    public void add_score(int val)
    {
        Score += val;
    }
    public void add_click_score(int val)
    {
        ClickScore += val;
    }
    public void sub_click_score(int val)
    {
        ClickScore -= val;
    }
    public int getDamage() => ClickScore;
    public int Get_block_hp() => current_block_hp;
    public int Get_current_total_block_hp() => current_total_block_hp;
    public string Get_block_name() => current_block_name;
    public void Set_block_hp(int hp)
    {
        current_block_hp = hp;
    }
    public void Set_block_name(string name)
    {
        current_block_name = name;
    }
    public void Hit()
    {
        if (current_block_hp > ClickScore)
        {
            current_block_hp -= ClickScore;
        }
        else
        {
            GameObject blockObject = GameObject.Find(current_block_name);
            blockObject.SetActive(false);

            blockDestroyedSound.Play();

            (int new_hp, string new_name) = button_spawner.SpawnRandomButtons();
            current_total_block_hp = new_hp;
            string name = Get_block_name();

            GameObject blockPrefab = null;
            int c;
            if(name == "DirtBlock")
            {
                c = int.Parse(CountArray[0].text);
                CountArray[0].text = (c + 1).ToString();
                blockPrefab = dirtPrefab;
            }
            else if(name == "StoneBlock")
            {
                c = int.Parse(CountArray[1].text);
                CountArray[1].text = (c + 1).ToString();
                blockPrefab = stonePrefab;
            }
            else if(name == "DeepslateBlock")
            {
                c = int.Parse(CountArray[2].text);
                CountArray[2].text = (c + 1).ToString();
                blockPrefab = DeepPrefab;
            }            
            else if(name == "IronBlock")
            {
                c = int.Parse(CountArray[3].text);
                CountArray[3].text = (c + 1).ToString();
                blockPrefab = IronPrefab;
            }
            else if(name == "GoldBlock")
            {
                c = int.Parse(CountArray[4].text);
                CountArray[4].text = (c + 1).ToString();
                blockPrefab = GoldPrefab;
            }
            else if(name == "RedstoneBlock")
            {
                c = int.Parse(CountArray[5].text);
                CountArray[5].text = (c + 1).ToString();
                blockPrefab = RedsPrefab;
            }
            else if(name == "LazuriteBlock")
            {
                c = int.Parse(CountArray[6].text);
                CountArray[6].text = (c + 1).ToString();
                blockPrefab = LazurPrefab;
            }             
            else if(name == "EmeraldBlock")
            {
                c = int.Parse(CountArray[7].text);
                CountArray[7].text = (c + 1).ToString();
                blockPrefab = EmeraldPrefab;
            }
            else if(name == "DiamondBlock")
            {
                c = int.Parse(CountArray[8].text);
                CountArray[8].text = (c + 1).ToString();
                blockPrefab = DiamondPrefab;
            }

            if (blockPrefab != null)
            {
                GameObject newBlock = Instantiate(blockPrefab, blockObject.transform.position, Quaternion.identity);

                
                newBlock.transform.parent = blockObject.transform.parent;

                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));

                LeanTween.move(newBlock, targetPosition, 1.0f).setEaseOutQuad().setOnComplete(() =>
                {
                    Destroy(newBlock);
                });
            }
            backgroundMover.Move();
            Set_block_name(new_name);
            Set_block_hp(new_hp);
            
        }
    }

    private string ShowCost(int val)
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
            Costs[0] += 100;
            ClickScore += 2;
            CostWoodText.text = ShowCost(Costs[0]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
            if (PixesImage != null && woodUpgradeSprite != null)
            {
                if (!stoneUpgradeApplied && !ironUpgradeApplied && !goldUpgradeApplied && !diamondUpgradeApplied)
                {
                    currentSprite = woodUpgradeSprite;
                }

                PixesImage.sprite = currentSprite;
            }

            woodUpgradeApplied = true;

            
        }
    }
    

    public void OnClickStoneUpgrade()
    {
        if (Score >= Costs[1])
        {
            Score -= Costs[1];
            Costs[1] += 200;
            ClickScore += 4;
            CostStoneText.text = ShowCost(Costs[1]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }

            if (PixesImage != null && stoneUpgradeSprite != null)
            {
                if (!ironUpgradeApplied && !goldUpgradeApplied && !diamondUpgradeApplied)
                {
                    currentSprite = stoneUpgradeSprite;
                }

                PixesImage.sprite = currentSprite;
            }

            stoneUpgradeApplied = true;

         
        }
    }

    public void OnClickIronUpgrade()
    {
        if (Score >= Costs[2])
        {
            Score -= Costs[2];
            Costs[2] += 600;
            ClickScore += 6;
            CostIronText.text = ShowCost(Costs[2]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }
            if (PixesImage != null && ironUpgradeSprite != null)
            {
                if (!goldUpgradeApplied && !diamondUpgradeApplied)
                {
                    currentSprite = ironUpgradeSprite;
                }

                PixesImage.sprite = currentSprite;
            }

            ironUpgradeApplied = true;
        }
    }

    public void OnClickGoldUpgrade()
    {
        if (Score >= Costs[3])
        {
            Score -= Costs[3];
            Costs[3] += 1000;
            ClickScore += 8;
            CostGoldText.text = ShowCost(Costs[3]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }

            if (PixesImage != null && goldUpgradeSprite != null)
            {
                if (!diamondUpgradeApplied)
                {
                    currentSprite = goldUpgradeSprite;
                }

                PixesImage.sprite = currentSprite;
            }

            goldUpgradeApplied = true;
        }
    }

    public void OnClickDaimondUpgrade()
    {
        if (Score >= Costs[4])
        {
            Score -= Costs[4];
            Costs[4] += 2000;
            ClickScore += 10;
            CostDaimondText.text = ShowCost(Costs[4]) + "$";
            SoundController soundController = ButtonBuy.GetComponent<SoundController>();
            if (soundController != null)
            {
                soundController.OnClickSoundButton();
            }

            if (PixesImage != null && diamondUpgradeSprite != null)
            {
                currentSprite = diamondUpgradeSprite;
                PixesImage.sprite = currentSprite;
            }

            diamondUpgradeApplied = true;
        }
    }


    public void OnClickCoalBuy()
    {
        if (Score >= coalcost)
        {
            Score -= coalcost;
            int current_coal = Int32.Parse(coal_out.text);
            coal_out.text = Convert.ToString(current_coal + 1);
        }
    }
    private void Update()
        {
            ScoreText.text = ShowCost(Score);
            DamageText.text = Convert.ToString(ClickScore);

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
