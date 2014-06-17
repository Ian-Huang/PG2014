using UnityEngine;
using System.Collections;

/// <summary>
/// 處理NPC
/// </summary>
public class NPC : MonoBehaviour
{
    public GameDefinition.Mission Mission;
    public GameDefinition.GameType Gametype;

    public float AmplifyScale;  //放大倍率
    private float originScale;  //原始倍率

    public Sprite Normal_Sprite;
    public Sprite Active_Sprite;

    [HideInInspector]
    public bool isChoosed = false; //是否被選中

    void OnEnable()
    {
        //NPC 淡入畫面
        iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", 0,
                "to", 1,
                "time", 0.75f,
                "onupdate", "NPCAppear"   //動畫進行 callback
                ));
    }

    void OnMouseEnter()
    {
        if (!this.isChoosed)
        {
            //滑鼠移進角色按鈕，按鈕放大(AmplifyScale 決定)
            iTween.ScaleTo(this.gameObject, iTween.Hash(
                    "scale", Vector3.one * this.AmplifyScale,
                    "time", 1
                    ));
            //更換為外光暈圖
            this.GetComponent<SpriteRenderer>().sprite = this.Active_Sprite;
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
            //更換為原始圖
            this.GetComponent<SpriteRenderer>().sprite = this.Normal_Sprite;
        }
    }

    void OnMouseUpAsButton()
    {
        if (!this.isChoosed)
        {
            //將所有 NPC 設為被選擇，避免被誤觸
            foreach (NPC tempScript in this.transform.parent.GetComponentsInChildren<NPC>())
                tempScript.isChoosed = true;    //設定為已被選中

            EventCollection.script.NextEvent();     //切換下一事件

            //紀錄目前被選擇的任務名
            GameDefinition.CurrentChooseMission = this.Mission;
            //紀錄目前選擇的遊戲類型
            GameDefinition.CurrentChooseGameType = this.Gametype;

            //設定 目前被選任務名的詢問對話
            GameObject.FindObjectOfType<TextMeshAppear>().ResetText("確定要進行" + "\"" + this.Mission + "\"" + "任務嗎？");
        }
    }

    /// <summary>
    /// 重設所有狀態， 回復原始大小、被選狀態取消、圖片回到Normal
    /// </summary>
    public void Reset()
    {
        this.transform.localScale = Vector3.one * this.originScale;
        this.GetComponent<SpriteRenderer>().sprite = this.Normal_Sprite;
        this.isChoosed = false;
    }

    // Use this for initialization
    void Start()
    {
        this.originScale = this.transform.localScale.x;     //紀錄原始scale大小
    }

    /// <summary>
    /// ITween 動畫 Update (顏色出現)
    /// </summary>
    /// <param name="a"></param>
    void NPCAppear(float a)
    {
        //將NPC淡入，包含(1)Sprite NPC本身、(2)TextMesh任務名、(3)Sprite任務框
        SpriteRenderer npcSR = this.GetComponent<SpriteRenderer>();
        TextMesh missionTM = this.GetComponentInChildren<TextMesh>();
        SpriteRenderer missionSR = this.GetComponentInChildren<SpriteRenderer>();

        npcSR.color = new Color(npcSR.color.r, npcSR.color.g, npcSR.color.b, a);
        missionTM.color = new Color(missionTM.color.r, missionTM.color.g, missionTM.color.b, a);
        missionSR.color = new Color(missionSR.color.r, missionSR.color.g, missionSR.color.b, a);
    }
}
