using UnityEngine;
using System.Collections;

/// <summary>
/// 輸入腳色名字
/// </summary>
public class RoleNameEnter : MonoBehaviour
{
    public GameObject HintObject;   //提示物件
    public GameObject SureObject;   //確認按鈕
    public Rect UIRect;
    [HideInInspector]
    public string EnterNameString;  //輸入名字

    public GUIStyle style;
    private int originFontSize;

    void Start()
    {
        this.EnterStringEmpty();
        this.originFontSize = this.style.fontSize;
    }

    void OnGUI()
    {
        this.style.fontSize = Mathf.FloorToInt(this.originFontSize * ((float)Screen.width / 640.0f));

        this.EnterNameString = GUI.TextField(
            new Rect(this.UIRect.x * Screen.width, this.UIRect.y * Screen.height, this.UIRect.width * Screen.width, this.UIRect.height * Screen.height),
            this.EnterNameString, 5, this.style);

        //假如輸入框輸入內容產生改變
        if (GUI.changed)
        {
            //名字長度 =0，顯示輸入提示，確認按鈕關閉
            if (this.EnterNameString.Length == 0)
            {
                this.EnterStringEmpty();
            }
            else
            {
                this.HintObject.SetActive(false);
                this.SureObject.SetActive(true);
            }
        }
    }

    public void EnterStringEmpty()
    {
        this.EnterNameString = string.Empty;
        this.HintObject.SetActive(true);
        this.SureObject.SetActive(false);
    }
}