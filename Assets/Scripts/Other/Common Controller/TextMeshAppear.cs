using UnityEngine;
using System.Collections;

/// <summary>
/// 通用函式，TextMesh 文件依序出現控制
/// </summary>
public class TextMeshAppear : MonoBehaviour
{
    public float AppearTime;            //過程花費時間
    public float DelayTime;             //延遲時間
    public bool isNextEvent = false;    //文字完成後是否進行事件切換 (EventCollection script)

    private bool isComplete;    //確認文字出現是否完成
    private TextMesh textMesh;
    public string ShowString;  //儲存字串

    // Use this for initialization
    void Start()
    {
        this.textMesh = this.GetComponent<TextMesh>();

        //確認是否有掛載系統名字
        DialogName nameScript = null;
        if ((nameScript = this.GetComponent<DialogName>()) != null)
        {
            if (nameScript.dialogName != GameDefinition.DialogName.None)
                this.ShowString = nameScript.dialogName.ToString();
            else
                this.ShowString = this.textMesh.text;
        }
        else
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

    /// <summary>
    /// 文字出現Update函式
    /// </summary>
    /// <param name="value"></param>
    void TextUpdate(int value)
    {
        this.textMesh.text = this.ShowString.Substring(0, value);
    }

    /// <summary>
    /// 文字出現完成後呼叫
    /// </summary>
    void TextComplete()
    {
        this.isComplete = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))  //按下滑鼠左鍵
        {
            if (!this.isComplete)
            {
                //狀態如未完成，停止ITween動畫並顯示所有文字
                iTween.StopByName(this.gameObject, "TextAppear");
                this.textMesh.text = this.ShowString;
                this.isComplete = true;
            }
            else
            {
                //判斷是否會進行下一事件切換
                if (this.isNextEvent)
                {
                    EventCollection.script.NextEvent(); //切換下一事件
                    this.enabled = false;   //關閉此script，避免再度觸發
                }
            }
        }
    }
}
