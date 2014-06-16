using UnityEngine;
using System.Collections;

public class RoleActionController : MonoBehaviour
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

        if (RudderRotate.script != null)
            iTween.Stop(RudderRotate.script.gameObject);

        if (NPCTalkingManager.script != null)
        {
            NPCTalkingManager.script.NextTalk();
        }
    }

    void RoleColorTo(Color c)
    {
        this.boneAnimation.SetMeshColor(c);
    }
}