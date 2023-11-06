using UnityEngine;

public class SetTimerButton : MonoBehaviour
{
    public Timer timerScript;
    public int damage_to_upgrade;

    private void Start()
    {
        if (timerScript == null)
        {
            timerScript = FindObjectOfType<Timer>();
        }
    }

    public void SetAndStartTimer()
    {
        Game GameObj = FindObjectOfType<Game>();
        damage_to_upgrade = GameObj.getDamage();


        timerScript.SetTime(2, 0); 
        timerScript.StartTimer();
        GameObj.add_click_score(damage_to_upgrade);

        timerScript.StopTimer(); 
        GameObj.sub_click_score(damage_to_upgrade);
        
    }
}
