using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour
{
    public SmoothMoves.BoneAnimation boneAnimation;
    public RoleActionType ActionType;

    void OnMouseEnter()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one * 0.0025f, "time", 0.5f));
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", this.boneAnimation.mMeshColor,
            "to", new Color(1, 1, 1, 1),
            "onupdate", "RoleColorTo",
            "time", 0.5f));

    }

    void OnMouseExit()
    {
        iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.one * 0.0020f, "time", 0.5f));
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "from", this.boneAnimation.mMeshColor,
             "to", new Color(0.25f, 0.25f, 0.25f, 1),
            "onupdate", "RoleColorTo",
            "time", 0.5f));
    }

    void RoleColorTo(Color c)
    {
        this.boneAnimation.SetMeshColor(c);
    }

    // Use this for initialization
    void Start()
    {
        this.boneAnimation = this.GetComponent<SmoothMoves.BoneAnimation>();
        this.boneAnimation.playAutomatically = false;
        this.boneAnimation.SetMeshColor(new Color(0.25f, 0.25f, 0.25f, 1));
        if (this.ActionType == RoleActionType.walk)
            this.boneAnimation.Play("walk");
        else
            this.boneAnimation.Play("idle");


    }

    // Update is called once per frame
    void Update()
    {

    }


    public enum RoleActionType
    {
        idle = 0, walk = 1
    }
}
