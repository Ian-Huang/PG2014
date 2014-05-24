using UnityEngine;
using System.Collections;

public class RoleButtonController : MonoBehaviour
{
    public GameDefinition.SystemPlayerName SystemName;

    public float AmplifyScale;  //放大倍率
    private float originScale;  //原始倍率



    void OnMouseEnter()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash(
                "scale", Vector3.one * this.AmplifyScale,
                "time", 1
                ));
    }

    void OnMouseExit()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash(
                "scale", Vector3.one * this.originScale,
                "time", 1
                ));
    }

    void OnMouseUpAsButton()
    {

    }

    // Use this for initialization
    void Start()
    {
        this.originScale = this.transform.localScale.x;     //紀錄原始scale大小

        this.GetComponentInChildren<TextMesh>().text = GameDefinition.PlayerNameData[this.SystemName];
    }
}