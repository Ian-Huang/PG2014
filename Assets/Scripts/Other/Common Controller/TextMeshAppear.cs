using UnityEngine;
using System.Collections;

public class TextMeshAppear : MonoBehaviour
{
    public float AppearTime;
    public float DelayTime;

    private TextMesh textMesh;
    private string ShowString;

    // Use this for initialization
    void Start()
    {
        this.textMesh = this.GetComponent<TextMesh>();
        this.ShowString = this.textMesh.text;
        this.textMesh.text = string.Empty;

        iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", 0,
                "to", this.ShowString.Length,
                "time", this.AppearTime,
                "delay", this.DelayTime,
                "onupdate", "TextUpdate",
                "oncomplete", "TextComplete",
                "easetype", iTween.EaseType.linear));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextUpdate(int value)
    {
        this.textMesh.text = this.ShowString.Substring(0, value);
    }

    void TextComplete()
    {

    }
}
