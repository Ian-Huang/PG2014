using UnityEngine;
using System.Collections;

/// <summary>
/// 角色按鈕屬性
/// </summary>
public class RoleButton : MonoBehaviour
{
    public GameDefinition.SystemPlayerName SystemName;

    public float AmplifyScale;  //放大倍率
    private float originScale;  //原始倍率

    private bool isChoosed = false; //是否被選中

    void OnMouseEnter()
    {
        if (!this.isChoosed)
        {
            //滑鼠移進角色按鈕，按鈕放大(AmplifyScale 決定)
            iTween.ScaleTo(this.gameObject, iTween.Hash(
                    "scale", Vector3.one * this.AmplifyScale,
                    "time", 1
                    ));
        }
    }

    void OnMouseExit()
    {
        if (!this.isChoosed)
        {
            //滑鼠移出角色按鈕，按鈕回到原始大小
            iTween.ScaleTo(this.gameObject, iTween.Hash(
                    "scale", Vector3.one * this.originScale,
                    "time", 1
                    ));
        }
    }

    void OnMouseUpAsButton()
    {
        if (!this.isChoosed)
        {
            foreach (RoleButton tempScript in this.transform.parent.GetComponentsInChildren<RoleButton>())
            {
                //將沒被選中的角色按鈕關閉 
                if (tempScript != this)
                    tempScript.gameObject.SetActive(false);
            }

            // ITween 動畫， 將被選中的按鈕移動至 預先設定的位置與大小(RoleButtonController scipt 的 ChoosePropertiesObject)
            iTween.ScaleTo(this.gameObject, iTween.Hash(
                    "scale", RoleButtonController.script.ChoosePropertiesObject.transform.localScale,
                    "time", 1
                    ));
            iTween.MoveTo(this.gameObject, iTween.Hash(
                    "position", RoleButtonController.script.ChoosePropertiesObject.transform.position,
                    "time", 1
                    ));

            this.isChoosed = true;  //設定為已被選中

            EventCollection.script.NextEvent();
        }
    }

    // Use this for initialization
    void Start()
    {
        this.originScale = this.transform.localScale.x;     //紀錄原始scale大小

        this.GetComponentInChildren<TextMesh>().text = GameDefinition.PlayerNameData[this.SystemName];  //抓取系統儲存的玩家名字
    }
}