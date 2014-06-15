using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public GameDefinition.ButtonEvent buttonEvent;

    void OnMouseUpAsButton()
    {
        switch (this.buttonEvent)
        {
            case GameDefinition.ButtonEvent.SureButton_RoleSelect:
                RoleSelectController.script.SavePlayerNameToSystem();
                break;
            case GameDefinition.ButtonEvent.RightArrow_RoleSelect:
                RoleSelectController.script.RunRightCard();
                break;
            case GameDefinition.ButtonEvent.LeftArrow_RoleSelect:
                RoleSelectController.script.RunLeftCard();
                break;
            case GameDefinition.ButtonEvent.MissionSure_Area:   //選擇任務確認:確定
                GameObject.FindObjectOfType<CameraChangeBackground>().ToMissionBackground();
                break;
            case GameDefinition.ButtonEvent.MissionCancel_Area: //選擇任務確認:取消
                EventCollection.script.BackEvent(); //退回前一事件(選NPC任務)
                GameDefinition.CurrentChooseMission = GameDefinition.Mission.None;                
                //重設NPC狀態
                foreach (NPC script in GameObject.FindObjectsOfType<NPC>())
                    script.Reset();
                break;

            default:
                break;
        }
    }
}