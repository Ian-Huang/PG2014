using UnityEngine;
using System.Collections;

public class FindDifferentGame_Manager : MonoBehaviour
{

    public AudioClip CorrectSound;
    public AudioClip ErrorSound;

    public static FindDifferentGame_Manager script;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.FindCorrect:
                this.audio.clip = this.CorrectSound;
                break;
            case SoundType.FindError:
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

    public enum SoundType
    {
        FindCorrect = 0, FindError = 1
    }
}
