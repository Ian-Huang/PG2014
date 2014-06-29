using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public TextMesh MinuteText;
    public TextMesh SecondText;

    public TimerEndtoDo EndtoDo;
    public bool isStartRun = false;
    public int CountDownSecond;

    // Use this for initialization
    IEnumerator Start()
    {
        this.MinuteText.text = "";
        this.SecondText.text = "";
        yield return new WaitForSeconds(this.GetComponent<ColorTo>().DelayTime + this.GetComponent<ColorTo>().ChangeTime);

        this.MinuteText.text = (this.CountDownSecond / 60).ToString("00");
        this.SecondText.text = (this.CountDownSecond % 60).ToString("00");

        if (this.isStartRun)
            InvokeRepeating("RunTimer", 1, 1);
    }

    public void StartTimer()
    {
        InvokeRepeating("RunTimer", 1, 1);
    }

    void RunTimer()
    {
        this.CountDownSecond--;

        if (this.CountDownSecond < 0)
        {
            switch (this.EndtoDo)
            {
                case TimerEndtoDo.NextGameStep:
                    GameCollection.script.NextGameStep();
                    break;
                default:
                    break;
            }

            CancelInvoke("RunTimer");
        }
        else
        {
            this.MinuteText.text = (this.CountDownSecond / 60).ToString("00");
            this.SecondText.text = (this.CountDownSecond % 60).ToString("00");
        }
    }

    public enum TimerEndtoDo
    {
        Nothing = 0, NextGameStep = 1
    }
}
