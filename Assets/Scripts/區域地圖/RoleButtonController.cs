using UnityEngine;
using System.Collections;

public class RoleButtonController : MonoBehaviour
{
    public float AmplifyScale;
    private float originScale;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
