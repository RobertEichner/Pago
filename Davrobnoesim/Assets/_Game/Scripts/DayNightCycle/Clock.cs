using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private int gameMinutes = 0;
    private bool isRunning = true;

    public Text instruction;

    void Start()
    {
        instruction = GetComponent<Text>();
    }

    void OnEnable()
    {
        StartCoroutine(GameClock());
    }

    private IEnumerator GameClock()
    {
        while (isRunning)
        {
            gameMinutes++;
            if (gameMinutes >= 10080) //Reset to Monday 0:00 am
            {          
                gameMinutes = 0;
                
            }
            instruction.text = toString(gameMinutes);
            Debug.Log(toString(gameMinutes));
            yield return new WaitForSeconds(1f);
        }
    }

    private int getMinute(int t)
    {
        return t % 60;
    }

    private int getHour(int t)
    {
        return t/60 %24;
    }

    private int getWeekday(int t)
    {
        return t/60/24;
    }

    private string toString(int t)
    {
        string[] id = {"Mon","Tue","Wed","Thu","Fri","Sat","Sun"};
        string weekDay = id[getWeekday(t)];

        return weekDay + " " +  (getHour(t)).ToString("D2") + ":" + getMinute(t).ToString("D2");  
    }
}
