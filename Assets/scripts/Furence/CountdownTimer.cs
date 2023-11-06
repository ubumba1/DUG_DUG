using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public ButtonMovement[] buttons;
    public Text CoalText;

    private bool timerActive = false;
    private float countdownTime = 4f;
    private float initialCountdownTime;
    private string[] previousButtonText;
    private string previousCoalText;

    public bool IsTimerActive()
    {
        return timerActive;
    }

    void Start()
    {
        initialCountdownTime = countdownTime;

     
        previousButtonText = new string[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            previousButtonText[i] = buttons[i].buttonText.text;
        }
        previousCoalText = CoalText.text;
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
                                if (!timerActive)
                                {
                                    StartTimer();
                                }
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

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].buttonText.text != previousButtonText[i])
            {
                previousButtonText[i] = buttons[i].buttonText.text;

                int currentValue;
                if (int.TryParse(buttons[i].buttonText.text, out currentValue) && currentValue > 0)
                {
                    StartTimer();
                }
                return;
            }
        }

        if (CoalText.text != previousCoalText)
        {
            previousCoalText = CoalText.text;

            int currentCoal;
            if (int.TryParse(CoalText.text, out currentCoal) && currentCoal > 0)
            {
                StartTimer();
            }
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
