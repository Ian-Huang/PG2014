using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCTalkingManager : MonoBehaviour
{
    public GameObject BackgroundObject; //背景物件(將會根據不同任務作圖片切換)
    public float CameraMoveOffsetX;     //轉場Camera X 位置量

    public GameObject SpecialNPC_Chef;  //特殊NPC

    public List<TalkingData> TalkingDataList;   //所有任務對話清單
    [HideInInspector]
    public TalkingData CurrentTalkingData;  //當前任務對話資訊

    public int CurrentTalkIndex = 0;    //紀錄目前對話索引值

    public static NPCTalkingManager script;

    public void ToMissionTalking()
    {
        //轉場
        iTween.MoveTo(Camera.main.gameObject, iTween.Hash(
                 "x", Camera.main.gameObject.transform.position.x + this.CameraMoveOffsetX,
                 "time", 1.25f,
                 "oncomplete", "MoveComplete",
                 "oncompletetarget", this.gameObject
                 ));

        //找出目前選擇任務的資訊
        this.CurrentTalkingData = this.TalkingDataList.Find((TalkingData data) =>
        {
            if (data.Mission == GameDefinition.CurrentChooseMission)
                return true;
            else
                return false;
        });

        //設定目前任務對話"背景"和"對話NPC"
        this.BackgroundObject.GetComponent<SpriteRenderer>().sprite = this.CurrentTalkingData.BackgroundSprite;
        this.CurrentTalkingData.NPCObject.SetActive(true);
    }

    void MoveComplete()
    {
        //假如有旁白，對話框與腳色同時出現
        if (this.CurrentTalkingData.Mission == GameDefinition.Mission.卡片掉了)
        {
            this.NextTalk();
        }

        //Role 出場 
        RoleAnimationCollection.script.RoleAppear(GameDefinition.CurrentChoosePlayerName);
    }

    /// <summary>
    /// 呼叫下一句對話框
    /// </summary>
    public void NextTalk()
    {
        if (this.CurrentTalkIndex != 0)
        {
            if (GameDefinition.CurrentChooseMission == GameDefinition.Mission.奶油水果派 && this.CurrentTalkIndex == 1)
            {
                this.SpecialNPC_Chef.SetActive(true);
                iTween.RotateTo(this.SpecialNPC_Chef, iTween.Hash(
                    "y", 2160,
                    "time", 1,
                    "easetype", iTween.EaseType.easeOutQuad
                ));
            }
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex - 1].SetActive(false);    //關閉前一事件物件            
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex].SetActive(true);     //開啟新一事件物件
            this.CurrentTalkIndex++;
        }
        else
        {
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex].SetActive(true);     //開啟新一事件物件
            this.CurrentTalkIndex++;
        }
    }

    void Awake()
    {
        script = this;
    }

    [System.Serializable]
    public class TalkingData
    {
        public GameDefinition.Mission Mission;
        public GameObject NPCObject;
        public Sprite BackgroundSprite;
        public List<GameObject> BeginTalkContentList;
    }
}