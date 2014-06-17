﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCollection : MonoBehaviour
{
    public List<GameData> GameDataList;
    public GameObject CurrentCloneGameObject;   //目前對話腳色(複製)
    [HideInInspector]
    public GameData CurrentGameData;  //當前遊戲資訊

    public int CurrentGameStepIndex = 0;    //紀錄遊戲流程索引值

    public static GameCollection script;

    void Awake()
    {
        script = this;
    }

    /// <summary>
    /// 開始進行目前選定遊戲的開頭
    /// </summary>
    public void GameOpening()
    {
        //找出將進行遊戲類型的資料
        this.CurrentGameData = this.GameDataList.Find((GameData data) =>
        {
            if (data.Game_Type == GameDefinition.CurrentChooseGameType)
            {
                //this.CurrentCloneGameObject = Instantiate(data.Game_Object) as GameObject;
                //this.CurrentCloneGameObject.transform.parent = this.transform;
                //this.CurrentCloneGameObject.SetActive(true);
                return true;
            }
            else
                return false;
        });

        //開啟遊戲物件
        this.CurrentGameData.Game_Object.SetActive(true);

        //遊戲階段索引值從0開始
        this.CurrentGameStepIndex = 0;
    }

    /// <summary>
    /// 目前遊戲進入下一階段
    /// </summary>
    public void NextGameStep()
    {
        this.CurrentGameData.GameStepList[this.CurrentGameStepIndex].SetActive(false);    //關閉前一事件物件
        this.CurrentGameStepIndex++;
        this.CurrentGameData.GameStepList[this.CurrentGameStepIndex].SetActive(true);     //開啟新一事件物件
    }

    [System.Serializable]
    public class GameData
    {
        public GameDefinition.GameType Game_Type;
        public GameObject Game_Object;
        public List<GameObject> GameStepList;
    }
}
