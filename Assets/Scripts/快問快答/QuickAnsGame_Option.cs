using UnityEngine;
using System.Collections;

public class QuickAnsGame_Option : MonoBehaviour
{
    public int OptionNumber;

    void OnMouseEnter()
    {
        if (QuickAnsGame_Manager.script.CanChoose)
            this.GetComponent<TextMesh>().color = QuickAnsGame_Manager.script.OptionActiveColor;
    }

    void OnMouseExit()
    {
        if (QuickAnsGame_Manager.script.CanChoose)
            this.GetComponent<TextMesh>().color = QuickAnsGame_Manager.script.OptionNormalColor;
    }

    void OnMouseUpAsButton()
    {
        if (QuickAnsGame_Manager.script.CanChoose)
        {
            //答對處理
            if (this.OptionNumber == QuickAnsGame_Manager.script.CurrentQuestionData.TrueAnswer)
            {
                QuickAnsGame_Manager.script.StartShowAnswer(true);
            }
            //答錯處理
            else
            {
                QuickAnsGame_Manager.script.StartShowAnswer(false);
            }
        }
    }
}