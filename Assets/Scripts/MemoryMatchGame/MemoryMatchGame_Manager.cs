using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryMatchGame_Manager : MonoBehaviour
{
    public AudioClip CorrectSound;
    public AudioClip ErrorSound;

    public List<GameObject> CardCollection;

    public State CurrentState;
    public GameObject targetMatchObject = null;

    public static MemoryMatchGame_Manager script;

    // Use this for initialization
    void Start()
    {
        foreach (var temp in this.GetComponentsInChildren<MemoryMatchGame_Card>())
            this.CardCollection.Add(temp.gameObject);

        this.CurrentState = State.StopGame;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, Screen.height - 50, 100, 50), "開始遊戲"))
        {
            //開始遊戲(測試)
            foreach (var temp in this.GetComponentsInChildren<MemoryMatchGame_Card>())
            {
                temp.canRotate = true;
                temp.RotateCard(MemoryMatchGame_Card.CardFaceType.Back);
            }
            this.CurrentState = State.StartGame;
        }
    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.MatchCorrect:
                this.audio.clip = this.CorrectSound;
                break;
            case SoundType.MatchError:
                this.audio.clip = this.ErrorSound;
                break;
            default:
                break;
        }

        this.audio.Play();
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