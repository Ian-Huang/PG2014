using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleSelectController : MonoBehaviour
{
    public GameObject CurrentChooseRoleObject;

    public List<Transform> SaveRoleCardTransformList;
    private List<Vector3> roleCardPositionList;
    private List<Vector3> roleCarScaleList;

    private bool isChanging;

    public static RoleSelectController script;

    void Awake()
    {
        script = this;
    }

    // Use this for initialization
    void Start()
    {
        this.isChanging = false;

        this.roleCardPositionList = new List<Vector3>();
        this.roleCarScaleList = new List<Vector3>();
        foreach (Transform temp in this.SaveRoleCardTransformList)
        {
            this.roleCardPositionList.Add(temp.position);
            this.roleCarScaleList.Add(temp.localScale);
        }
    }

    /// <summary>
    /// 人物選擇列，向右移動一張卡片
    /// </summary>
    public void RunRightCard()
    {
        if (!this.isChanging)
        {
            RoleCard newFirstCard = null;
            RoleCard newLastCard = null;
            RoleCard centerCard = null;

            foreach (RoleCard temp in this.GetComponentsInChildren<RoleCard>())
            {
                if (temp.CurrentPositionIndex == 6)
                {
                    newFirstCard = temp;    //紀錄新的第一張卡片資訊
                    temp.CurrentPositionIndex = 0;
                    temp.transform.position = this.roleCardPositionList[temp.CurrentPositionIndex];
                }
                else
                {
                    if (temp.CurrentPositionIndex == 5) //紀錄新的最後一張卡片資訊
                        newLastCard = temp;

                    temp.CurrentPositionIndex++;
                    temp.MoveTo(this.roleCardPositionList[temp.CurrentPositionIndex]);

                    //控制卡片縮放(中間放大)
                    if (temp.CurrentPositionIndex == 4)
                        temp.ScaleTo(this.roleCarScaleList[temp.CurrentPositionIndex]);
                    if (temp.CurrentPositionIndex == 3)
                    {
                        centerCard = temp;
                        temp.ScaleTo(this.roleCarScaleList[temp.CurrentPositionIndex]);
                    }
                }
            }

            //新的第一張卡片要等於最後一張卡片(未完成)
            newFirstCard.gameObject.GetComponent<SpriteRenderer>().sprite = newLastCard.gameObject.GetComponent<SpriteRenderer>().sprite;
            newFirstCard.gameObject.GetComponentInChildren<TextMesh>().text = newLastCard.gameObject.GetComponentInChildren<TextMesh>().text;
            newFirstCard.RoleObject = newLastCard.RoleObject;

            //產生新人物由場景外走進場景
            Destroy(this.CurrentChooseRoleObject);
            this.CurrentChooseRoleObject = Instantiate(centerCard.RoleObject) as GameObject;

            //船舵旋轉
            RudderRotate.script.ChangeRotate();

            //切換狀態，卡片切換未完成時不可繼續切換
            this.isChanging = true;
            StartCoroutine(TimetoChangeBool(GameDefinition.CardChangeTime));
        }
    }

    /// <summary>
    /// 人物選擇列，向左移動一張卡片
    /// </summary>
    public void RunLeftCard()
    {
        if (!this.isChanging)
        {
            RoleCard newLastCard = null;
            RoleCard newFirstCard = null;
            RoleCard centerCard = null;

            foreach (RoleCard temp in this.GetComponentsInChildren<RoleCard>())
            {
                if (temp.CurrentPositionIndex == 0)
                {
                    newLastCard = temp;    //紀錄新的最後一張卡片資訊
                    temp.CurrentPositionIndex = 6;
                    temp.transform.position = this.roleCardPositionList[temp.CurrentPositionIndex];
                }
                else
                {
                    if (temp.CurrentPositionIndex == 1) //紀錄新的第一張卡片資訊
                        newFirstCard = temp;

                    temp.CurrentPositionIndex--;
                    temp.MoveTo(this.roleCardPositionList[temp.CurrentPositionIndex]);
                    //控制卡片縮放(中間放大)
                    if (temp.CurrentPositionIndex == 2)
                        temp.ScaleTo(this.roleCarScaleList[temp.CurrentPositionIndex]);
                    if (temp.CurrentPositionIndex == 3)
                    {
                        centerCard = temp;
                        temp.ScaleTo(this.roleCarScaleList[temp.CurrentPositionIndex]);
                    }
                }
            }

            //新的最後一張卡片要等於第一張卡片(未完成)
            newLastCard.gameObject.GetComponent<SpriteRenderer>().sprite = newFirstCard.gameObject.GetComponent<SpriteRenderer>().sprite;
            newLastCard.gameObject.GetComponentInChildren<TextMesh>().text = newFirstCard.gameObject.GetComponentInChildren<TextMesh>().text;
            newLastCard.RoleObject = newFirstCard.RoleObject;

            //產生新人物由場景外走進場景
            Destroy(this.CurrentChooseRoleObject);
            this.CurrentChooseRoleObject = Instantiate(centerCard.RoleObject) as GameObject;

            //船舵旋轉
            RudderRotate.script.ChangeRotate();

            //切換狀態，卡片切換未完成時不可繼續切換
            this.isChanging = true;
            StartCoroutine(TimetoChangeBool(GameDefinition.CardChangeTime));
        }
    }

    IEnumerator TimetoChangeBool(float time)
    {
        yield return new WaitForSeconds(time);
        this.isChanging = false;
    }
}