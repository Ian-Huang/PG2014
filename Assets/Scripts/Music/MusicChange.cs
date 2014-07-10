using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour
{
    public MusicManager.MusicType MusicType;   //音樂類型

    // Use this for initialization
    void Start()
    {
        MusicManager.script.PlaySound(this.MusicType);
    }
}