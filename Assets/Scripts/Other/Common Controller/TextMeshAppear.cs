using UnityEngine;
using System.Collections;

/// <summary>
/// 通用函式，TextMesh 文件依序出現控制
/// </summary>
public class TextMeshAppear : MonoBehaviour
{
    public float AppearTime;    //過程花費時間
    public float DelayTime;     //延遲時間

    private TextMesh textMesh;
    private string ShowString;  //儲存字串

    // Use this for initialization
    void Start()
    {
        this.textMesh = this.GetComponent<TextMesh>();
        this.ShowString = this.textMesh.text;

        this.textMesh.text = string.Empty;      //字串清空
        iTween.ValueTo(this.gameObject, iTween.Hash(
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

    }
}
