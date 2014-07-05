﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreasureController : MonoBehaviour
{
    public TreasureData treasureData;

    //霧片
    public GameObject OpenBlackScreen;
    public GameObject CloseBlackScreen;

    [HideInInspector]
    public SmoothMoves.BoneAnimation boneAnimation;
    [HideInInspector]
    public bool isCanTouch = false;

    public bool isActive = false;

    void OnMouseUpAsButton()
    {
        if (this.isCanTouch && !this.isActive)
        {
            //這邊判定目前系統對應的腳本是不是相同寶物，避免在問答中觸發到其他寶物
            if (GameDefinition.CurrentTreasureController_Script != null)
                if (GameDefinition.CurrentTreasureController_Script != this)
                    return;

            //目前進行的寶物，紀錄於系統
            GameDefinition.CurrentTreasureController_Script = this;

            this.isActive = true;
            this.OpenQuestion();
        }
    }

    void OpenQuestion()
    {
        //第一階段物品開啟，寶物問題
        this.treasureData.QuestionText.gameObject.SetActive(true);
        this.treasureData.SteleQuestionObject.SetActive(true);
        this.treasureData.ButtonObject.SetActive(true);

        //霧片開啟
        this.OpenBlackScreen.SetActive(true);
        this.CloseBlackScreen.SetActive(false);
    }

    public void OpenEpilogue()
    {
        //第一階段物品關閉
        this.treasureData.QuestionText.gameObject.SetActive(false);
        this.treasureData.SteleQuestionObject.SetActive(false);
        this.treasureData.ButtonObject.SetActive(false);

        //第二階段物品開啟，寶物結語
        this.treasureData.EpilogueText.gameObject.SetActive(true);
        this.treasureData.SteleEpilogueObject.SetActive(true);
    }

    public void CloseTreasure()
    {
        //第二階段物品關閉
        this.treasureData.EpilogueText.gameObject.SetActive(false);
        this.treasureData.SteleEpilogueObject.SetActive(false);

        //霧片關閉
        this.OpenBlackScreen.SetActive(false);
        this.CloseBlackScreen.SetActive(true);

        //轉換為金色寶物
        this.boneAnimation.Play("active");

        //移除系統紀錄寶物腳本狀態
        GameDefinition.CurrentTreasureController_Script = null;
    }


    // Use this for initialization
    void Start()
    {
        this.isActive = false;
        this.isCanTouch = false;
        this.boneAnimation = this.GetComponent<SmoothMoves.BoneAnimation>();
        this.boneAnimation.playAutomatically = false;
        this.boneAnimation.Play("put");
    }

    [System.Serializable]
    public class TreasureData
    {
        public GameDefinition.TreasureType treasureType;
        public GameObject ButtonObject;
        public GameObject SteleQuestionObject;
        public TextMesh QuestionText;
        public GameObject SteleEpilogueObject;
        public TextMesh EpilogueText;
    }
}