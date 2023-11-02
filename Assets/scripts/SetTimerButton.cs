using UnityEngine;

public class SetTimerButton : MonoBehaviour
{
    public Timer timerScript;

    private void Start()
    {
        
        if (timerScript == null)
        {
            timerScript = FindObjectOfType<Timer>();
        }
    }

    public void SetAndStartTimer()
    {
        timerScript.StopTimer(); 
        timerScript.SetTime(2, 0); 
        timerScript.StartTimer(); 
    }
}
