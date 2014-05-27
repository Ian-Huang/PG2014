using UnityEngine;
using System.Collections;

/// <summary>
/// 通用函式，TextMesh 文件依序出現控制
/// </summary>
public class TextMeshAppear : MonoBehaviour
{
    public float AppearTime;    //過程花費時間
    public float DelayTime;     //延遲時間
    public bool isNextEvent = false;

    private bool isComplete;
    private TextMesh textMesh;
    private string ShowString;  //儲存字串

    // Use this for initialization
    void Start()
    {
        this.textMesh = this.GetComponent<TextMesh>();
        this.ShowString = this.textMesh.text;

        this.isComplete = false;
        this.textMesh.text = string.Empty;      //字串清空
        iTween.ValueTo(this.gameObject, iTween.Hash(
                "name", "TextAppear",
                "from", 0,
                "to", this.ShowString.Length,
                "time", this.AppearTime,
                "delay", this.DelayTime,
                "onupdate", "TextUpdate",
                "oncomplete", "TextComplete",
                "easetype", iTween.EaseType.linear));
    }

    void TextUpdate(int value)
    {
        this.textMesh.text = this.ShowString.Substring(0, value);
    }

    void TextComplete()
    {
        this.isComplete = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!this.isComplete)
            {
                iTween.StopByName(this.gameObject, "TextAppear");
                this.textMesh.text = this.ShowString;
                this.isComplete = true;
            }
            else
            {
                if (this.isNextEvent)
                {
                    EventCollection.script.NextEvent();
                    this.enabled = false;
                }
            }
        }
    }
}
