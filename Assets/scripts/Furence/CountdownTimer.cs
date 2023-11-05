using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public ButtonMovement[] buttons;
    public Text CoalText;

    public static bool timerActive = false;
    private float countdownTime = 4f;
    private float initialCountdownTime;
    


    public bool IsTimerActive()
    {
        return timerActive;
    }

    void Start()
    {
        initialCountdownTime = countdownTime;

    }

    void Update()
    {
        if (timerActive)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 0;
                timerActive = false;


                foreach (ButtonMovement button in buttons)
                {
                    if (button.IsMoved)
                    {
                        int currentValue = int.Parse(button.buttonText.text);
                        int currentCoal = int.Parse(CoalText.text);
                        if (currentValue > 0 && currentCoal > 0)
                        {
                            button.buttonText.text = (currentValue - 1).ToString();
                            CoalText.text = (currentCoal - 1).ToString();
                            int currentImageValue = int.Parse(button.imageText.text);
                            button.imageText.text = (currentImageValue + 1).ToString();

                            if (currentCoal > 1 && currentValue > 1)
                            {
                                StartTimer();
                            }
                        }
                        return;
                    }
                }
            }

            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        int currentCoal = int.Parse(CoalText.text);
        if (currentCoal > 0)
        {
            timerActive = true;
            countdownTime = initialCountdownTime;
        }
    }

}
