using UnityEngine;

public class SpawnButtons : MonoBehaviour
{
    public GameObject[] buttonsToSpawn;
    public Transform spawnPoint;
    public float buttonWidth = 0.01f; 

    void Start()
    {
        SpawnRandomButtons();
    }

    void SpawnRandomButtons()
    {
        // remove spawnpoint condirion
        if (buttonsToSpawn.Length > 0 && spawnPoint != null)
        {
            float totalWidth = buttonsToSpawn.Length * buttonWidth;
            float startX = spawnPoint.position.x - totalWidth / 2;

            for (int i = 0; i < buttonsToSpawn.Length; i++)
            {
                float xPos = startX + i * buttonWidth;
                Vector3 spawnPosition = new Vector3(xPos, spawnPoint.position.y, spawnPoint.position.z);

                GameObject spawnedButton = Instantiate(buttonsToSpawn[i], spawnPosition, Quaternion.identity);
                spawnedButton.transform.SetParent(spawnPoint);
            }
        }
        else
        {
            Debug.LogWarning("Не установлены кнопки для спавна или точка появления.");
        }
    }
}
