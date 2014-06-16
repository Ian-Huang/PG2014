using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCTalkingManager : MonoBehaviour
{
    public List<TalkingData> TalkingDataList;

    public GameObject BackgroundObject;

    public Camera Maincamera;
    public float CameraX_SetPoint;

    public TalkingData CurrentTalkingData;

    public int CurrentTalkIndex = 0;

    public static NPCTalkingManager script;

    public GameObject ooo;

    public void ToMissionBackground()
    {
        iTween.MoveTo(this.Maincamera.gameObject, iTween.Hash(
                 "x", this.CameraX_SetPoint,
                 "time", 1.5f,
                 "oncomplete", "MoveComplete",
                 "oncompletetarget", this.gameObject
                 ));

        this.CurrentTalkingData = this.TalkingDataList.Find((TalkingData data) =>
        {
            if (data.Mission == GameDefinition.CurrentChooseMission)
                return true;
            else
                return false;
        });

        this.BackgroundObject.GetComponent<SpriteRenderer>().sprite = this.CurrentTalkingData.BackgroundSprite;
        this.CurrentTalkingData.NPCObject.SetActive(true);

    }

    void MoveComplete()
    {
        //假如有旁白...
        if (this.CurrentTalkingData.Mission == GameDefinition.Mission.卡片掉了)
        {
            print("!");
            this.NextTalk();
        }
        //Role 出場
        ooo.SetActive(true);
    }

    public void NextTalk()
    {
        if (this.CurrentTalkIndex != 0)
        {
            print(this.CurrentTalkIndex);
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex-1].SetActive(false);    //關閉前一事件物件            
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex].SetActive(true);     //開啟新一事件物件
            this.CurrentTalkIndex++;
        }
        else
        {
            this.CurrentTalkingData.BeginTalkContentList[this.CurrentTalkIndex].SetActive(true);     //開啟新一事件物件
            this.CurrentTalkIndex++;
        }
    }

    void Start()
    {

    }

    void Awake()
    {
        script = this;
    }

    [System.Serializable]
    public class BackgroundData
    {
        public GameDefinition.Mission Mission;
        public Sprite sprite;
    }

    [System.Serializable]
    public class TalkingData
    {
        //public SmoothMoves.BoneAnimation NPCBoneAnimation;
        //public Transform NPCPosition;
        public GameDefinition.Mission Mission;
        public GameObject NPCObject;
        public Sprite BackgroundSprite;
        public List<GameObject> BeginTalkContentList;
    }




}
