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
                GameObject.FindObjectOfType<NPCTalkingManager>().ToMissionTalking();
                break;
            case GameDefinition.ButtonEvent.MissionCancel_Area: //選擇任務確認:取消
                EventCollection.script.BackEvent(); //退回前一事件(選NPC任務)
                GameDefinition.CurrentChooseMission = GameDefinition.Mission.None;
                //重設NPC狀態
                foreach (NPC script in GameObject.FindObjectsOfType<NPC>())
                    script.Reset();
                break;
            case GameDefinition.ButtonEvent.NextGameStep:  //(暫定) 遊戲規則的開始遊戲按鈕 (未來依不同遊戲可能要分開)
                GameCollection.script.NextGameStep();
                break;
            case GameDefinition.ButtonEvent.GameEnd:    //(暫定) 關閉目前正在進行遊戲的主體
                GameCollection.script.CurrentGameData.Game_Object.SetActive(false);
                NPCTalkingManager.script.NextTalk();
                break;
            case GameDefinition.ButtonEvent.GameEnd_卡片掉了:    //(暫定) 特別: (記憶對對碰)卡片掉了任務 ， 關閉目前正在進行遊戲的主體
                GameCollection.script.CurrentGameData.Game_Object.SetActive(false);
                NPCTalkingManager.script.NextTalk();
                //把卡片收集者的動作改為Idle
                NPCTalkingManager.script.CurrentTalkingData.NPCObject.GetComponent<SmoothMoves.BoneAnimation>().Play("idle");
                break;
            case GameDefinition.ButtonEvent.HandSomethingGame_Correct:    //比手畫腳，答對按鈕
                if (HandSomethingGame_Manager.script.CanChooseButton)
                    HandSomethingGame_Manager.script.StartShowResult(true);
                break;
            case GameDefinition.ButtonEvent.HandSomethingGame_Giveup:    //比手畫腳，放棄按鈕
                if (HandSomethingGame_Manager.script.CanChooseButton)
                    HandSomethingGame_Manager.script.StartShowResult(false);
                break;
            default:
                break;
        }
    }
}