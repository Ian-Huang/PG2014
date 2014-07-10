using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public List<MusicData> MusicDataList;   //音樂資料清單

    private bool isAudioChange;
    public static MusicManager script;

    void Awake()
    {
        script = this;
    }

    // Use this for initialization
    void Start()
    {
        if (this.audio == null)
            this.gameObject.AddComponent<AudioSource>();

        this.isAudioChange = false;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="type">音效種類</param>
    public void PlaySound(MusicType type)
    {
        if (!this.isAudioChange)
        {
            //如果目前沒有播放音樂
            if (!this.audio.isPlaying)
            {
                if (type == MusicType.關閉)
                    return;

                this.audio.clip = this.MusicDataList.Find((MusicData data) =>
                {
                    return (data.musicType == type);
                }).musicClip;

                this.audio.Play();
            }
            //有播放音樂，則進行淡入淡出
            else
            {
                this.isAudioChange = true;
                iTween.AudioTo(this.gameObject, iTween.Hash(
                            "audiosource", this.audio,
                            "volume", 0,
                            "time", 1,
                            "oncompleteparams", type,
                            "easetype", iTween.EaseType.linear,
                            "oncomplete", "AudioChangeComplete"
                        ));
            }
        }
    }

    void AudioChangeComplete(MusicType type)
    {
        if (type == MusicType.關閉)
        {
            this.audio.clip = null;
            return;
        }

        this.audio.clip = this.MusicDataList.Find((MusicData data) =>
        {
            return (data.musicType == type);
        }).musicClip;

        this.isAudioChange = false;
        this.audio.Play();
        iTween.AudioTo(this.gameObject, iTween.Hash(
                        "audiosource", this.audio,
                        "volume", 1,
                        "easetype", iTween.EaseType.linear,
                        "time", 2
                    ));
    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 50, 50), "music 1"))
    //    {
    //        this.PlaySound(MusicType.關閉);
    //    }
    //    //if (GUI.Button(new Rect(0, 75, 50, 50), "music 2"))
    //    //{
    //    //    this.PlaySound(MusicType.正義的後繼);
    //    //}
    //}

    /// <summary>
    /// 音樂資料
    /// </summary>
    [System.Serializable]
    public class MusicData
    {
        public MusicType musicType; //音樂類型
        public AudioClip musicClip; //音樂片段
    }

    public enum MusicType
    {
        關閉 = 0, 前導配樂 = 1, 影片音樂 = 2, 地圖轉換音樂 = 3
    }
}
