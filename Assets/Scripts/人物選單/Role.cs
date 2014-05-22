using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour
{
    private SmoothMoves.BoneAnimation boneAnimation;

    // Use this for initialization
    IEnumerator Start()
    {
        this.boneAnimation = this.GetComponent<SmoothMoves.BoneAnimation>();
        this.boneAnimation.playAutomatically = false;
        this.boneAnimation.Play("walk");
        this.GetComponent<MoveTo>().Move();
        yield return new WaitForSeconds(this.GetComponent<MoveTo>().MoveTime);
        this.boneAnimation.Play("idle");
        iTween.Stop(RudderRotate.script.gameObject);
    }

    void RoleColorTo(Color c)
    {
        this.boneAnimation.SetMeshColor(c);
    }
}