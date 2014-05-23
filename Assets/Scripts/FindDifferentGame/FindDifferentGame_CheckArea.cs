using UnityEngine;
using System.Collections;

public class FindDifferentGame_CheckArea : MonoBehaviour
{
    public AreaType Areatype;

    public bool AlreadyFind;  //已經被找到(觸發)

    void OnMouseUpAsButton()
    {
        //確認是否已經被找到
        if (!this.AlreadyFind)
        {
            if (this.Areatype == AreaType.Correct)
            {
                //FindDifferentGame_Manager 播放正確音效
                FindDifferentGame_Manager.script.PlaySound(FindDifferentGame_Manager.SoundType.FindCorrect);
                this.GetComponentInChildren<MoveTo>().Move();
                this.AlreadyFind = true;
            }
            else
            {
                //FindDifferentGame_Manager 播放錯誤音效
                FindDifferentGame_Manager.script.PlaySound(FindDifferentGame_Manager.SoundType.FindError);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        this.AlreadyFind = false;
    }

    public enum AreaType
    {
        Correct = 0, Error = 1
    }
}
