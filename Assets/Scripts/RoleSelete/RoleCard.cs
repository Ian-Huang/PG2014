using UnityEngine;
using System.Collections;

public class RoleCard : MonoBehaviour
{
    private float originScale;
    public float targetScale;
    public float ChangeTime;

    void ScaleToLarge()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one * this.targetScale, "time", this.ChangeTime));
    }

    void ScaleToSmall()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one * this.originScale, "time", this.ChangeTime));
    }

    // Use this for initialization
    void Start()
    {
        this.originScale = this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "ScaleToLarge"))
        {
            this.ScaleToLarge();
        }
        if (GUI.Button(new Rect(300, 100, 100, 100), "ScaleToSmall"))
        {
            this.ScaleToSmall();
        }
    }
}
