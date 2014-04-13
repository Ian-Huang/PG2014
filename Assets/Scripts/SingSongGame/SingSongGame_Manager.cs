using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingSongGame_Manager : MonoBehaviour
{
    public List<SongTextData> SongTextDataList;
    private int currentIndex = 0;

    // Use this for initialization
    void Start()
    {
        foreach (var temp in this.SongTextDataList)
            temp.TextObject.SetActive(false);

    }

    void StartGame()
    {
        this.audio.Play();
        this.SongTextDataList[this.currentIndex].TextObject.SetActive(true);
        Invoke("ShowSongText", this.SongTextDataList[this.currentIndex].Time);
    }

    void ShowSongText()
    {
        if (this.currentIndex >= this.SongTextDataList.Count - 1)
            return;

        this.SongTextDataList[this.currentIndex].TextObject.SetActive(false);
        this.currentIndex++;
        this.SongTextDataList[this.currentIndex].TextObject.SetActive(true);
        Invoke("ShowSongText", this.SongTextDataList[this.currentIndex].Time);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, Screen.height - 50, 100, 50), "開始遊戲"))
        {
            this.StartGame();
        }
    }

    [System.Serializable]
    public class SongTextData
    {
        public GameObject TextObject;
        public float Time;
    }
}
