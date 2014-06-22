using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryMatchGame_Manager : MonoBehaviour
{
    public TextMesh TimerObject;
    public int TimerCount = 5;

    public AudioClip CorrectSound;
    public AudioClip ErrorSound;

    public List<GameObject> CardCollection;

    public State CurrentState;
    public GameObject targetMatchObject = null;

    public static MemoryMatchGame_Manager script;

    // Use this for initialization
    void Start()
    {
        //將所有 Card 儲存至清單
        foreach (var temp in this.GetComponentsInChildren<MemoryMatchGame_Card>())
            this.CardCollection.Add(temp.gameObject);

        this.CurrentState = State.StopGame;

        //開始看牌倒數計時
        this.InvokeRepeating("Timer", 1,1);
        this.TimerObject.text = this.TimerCount.ToString();
    }

    /// <summary>
    /// 看牌倒數計時器
    /// </summary>
    void Timer()
    {
        this.TimerCount--;
        if (this.TimerCount > 0)
            this.TimerObject.text = this.TimerCount.ToString();
        else if (this.TimerCount == 0)
        {
            this.StartGame();
            this.TimerObject.text = "GO";
        }
        else
        {
            this.TimerObject.text = "";
            this.CancelInvoke("Timer");
        }
    }

    /// <summary>
    /// 確認所有卡片是否都已翻開
    /// </summary>
    public void CheckCardOK()
    {
        bool isOK = true;
        foreach (var temp in this.GetComponentsInChildren<MemoryMatchGame_Card>())
        {
            if (temp.FaceType == MemoryMatchGame_Card.CardFaceType.Front && !temp.canRotate)
                continue;
            else
            {
                isOK = false;
                break;
            }
        }

        if (isOK)
        {
            //遊戲完成
            this.CurrentState = State.StopGame;

            //顯示下一階段 ， 統計成績(未完成)
            GameCollection.script.NextGameStep();
        }
    }

    /// <summary>
    /// 開始進行翻牌遊戲
    /// </summary>
    void StartGame()
    {
        //開始遊戲(測試)
        foreach (var temp in this.GetComponentsInChildren<MemoryMatchGame_Card>())
        {
            temp.canRotate = true;
            temp.RotateCard(MemoryMatchGame_Card.CardFaceType.Back);
        }
        this.CurrentState = State.StartGame;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="type">正確或錯誤音效</param>
    public void PlaySound(SoundType type)
    {
        // 待解問題: 遊戲結束後的那一瞬間，音效無法播放
        switch (type)
        {
            case SoundType.MatchCorrect:
                this.audio.PlayOneShot(this.CorrectSound);
                break;
            case SoundType.MatchError:
                this.audio.PlayOneShot(this.ErrorSound);
                break;
            default:
                break;
        }
    }

    void Awake()
    {
        script = this;
    }

    public enum State
    {
        StopGame = 0,   //遊戲停止
        StartGame = 1,  //遊戲開始
        Matching = 2,   //配對中
        Recover = 3     //卡片回復為反面的過程
    }

    public enum SoundType
    {
        MatchCorrect = 0, MatchError = 1
    }
}