using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    private TMP_Text _TimerText;
    [SerializeField] private int delta = 1;
    private bool isRunning = false;
    private Coroutine timerCoroutine; // Добавляем переменную для хранения корутины

    private void Start()
    {
        _TimerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
    }

    public void SetTime(int minutes, int seconds)
    {
        min = minutes;
        sec = seconds;
        UpdateTimerText();
    }

    public void StartTimer()
    {
        isRunning = true;
        timerCoroutine = StartCoroutine(ITimer());
    }

    public void StopTimer()
    {
        isRunning = false;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    IEnumerator ITimer()
    {
        while (isRunning)
        {
            if (sec == 0)
            {
                if (min == 0)
                {
                    StopTimer(); // Если время вышло, останавливаем таймер
                    break;
                }
                min--;
                sec = 59;
            }
            else
            {
                sec -= delta;
            }

            UpdateTimerText();
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateTimerText()
    {
        _TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
    }
}
