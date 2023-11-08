
using UnityEngine;
using UnityEngine.UI;

public class ShowDamaAuto : MonoBehaviour
{
    public GameObject AutodamageTextPrefab;

    public void ShowTextAuto(int damage)
    {
        GameObject damageTextObject = Instantiate(AutodamageTextPrefab);

        damageTextObject.transform.SetParent(transform.parent);

        Vector3 spawnPosition = transform.position + new Vector3(-6.5f, 1, -1);
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
