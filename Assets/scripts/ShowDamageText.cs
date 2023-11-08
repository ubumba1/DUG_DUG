using UnityEngine;
using UnityEngine.UI;

public class ShowDamageText : MonoBehaviour
{
    public GameObject damageTextPrefab;

    public void ShowText(int damage)
    {
        GameObject damageTextObject = Instantiate(damageTextPrefab);

        damageTextObject.transform.SetParent(GameObject.Find("Canvas").transform);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y+1, -1);
        damageTextObject.transform.position = spawnPosition;

        Text damageText = damageTextObject.GetComponent<Text>();
        damageText.text = damage.ToString();

        LeanTween.moveY(damageTextObject, damageTextObject.transform.position.y + 1, 0.3f).setEaseOutQuad().setOnComplete(() =>
        {
            Destroy(damageTextObject);
        });

        Destroy(damageTextObject, 5.0f);
    }
}
