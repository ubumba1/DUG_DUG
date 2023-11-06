using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnButtons : MonoBehaviour
{
    public GameObject[] buttonsToSpawn;
    [SerializeField] public int[] Block_HP = {100, 200, 400, 600, 600, 600, 600, 1000, 1500, 1600};  
    //dirt, stone, iron, gold, lazurite, redstone, izumrud, diamond
    // public Game game;
    private void Awake() {
        foreach(GameObject block in buttonsToSpawn)
        {
            block.SetActive(false);
        }
    }
    public (int, string) SpawnRandomButtons()
    {
        float[] buttonWeights = new float[buttonsToSpawn.Length];

        buttonWeights[1] = 0.5f;  // Dirt
        buttonWeights[2] = 0.4f;  // Stone
        buttonWeights[3] = 0.3f;  // deepsplate
        buttonWeights[4] = 0.2f;  // Iron
        buttonWeights[5] = 0.1f;  // Gold
        buttonWeights[6] = 0.05f; // Lazurite
        buttonWeights[7] = 0.04f; // Redstone
        buttonWeights[8] = 0.03f; // Izumrud
        buttonWeights[9] = 0.02f; // Diamond

        float totalWeight = buttonWeights.Sum();
        float randomValue = Random.Range(0f, totalWeight);

        // find index of chosen val
        int randomIndex = 0;
        float weightSum = 0f;
        for (int i = 0; i < buttonsToSpawn.Length; i++)
        {
            weightSum += buttonWeights[i];
            if (randomValue <= weightSum)
            {
                randomIndex = i;
                break;
            }
        }

        GameObject spawnedButton = buttonsToSpawn[randomIndex];
        spawnedButton.SetActive(true);

        string blockName = spawnedButton.name;
        int blockHP = Block_HP[randomIndex];
        Debug.Log(blockName + " блок активирован");

        return (blockHP, blockName);
    }

}
