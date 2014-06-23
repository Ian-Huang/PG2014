using UnityEngine;
using System.Collections;

public class RoleActionController : MonoBehaviour
{
    public AudioClip 碰撞音效;
    private SmoothMoves.BoneAnimation boneAnimation;

    // Use this for initialization
    IEnumerator Start()
    {
        //播放走路音效
        this.audio.Play();
        this.boneAnimation = this.GetComponent<SmoothMoves.BoneAnimation>();
        this.boneAnimation.playAutomatically = false;
        this.boneAnimation.Play("walk");
        this.GetComponent<MoveTo>().Move();

        yield return new WaitForSeconds(this.GetComponent<MoveTo>().MoveTime);

        //停止走路音效
        this.audio.Stop();
        //播放 idle動作
        this.boneAnimation.Play("idle");

        //選角頁面使用
        if (RudderRotate.script != null)
            iTween.Stop(RudderRotate.script.gameObject);

        //區域地圖使用
        if (NPCTalkingManager.script != null)
        {
            if (NPCTalkingManager.script.CurrentTalkingData.Mission == GameDefinition.Mission.卡片掉了)
            {
                //鏡頭震動
                iTween.ShakePosition(Camera.main.gameObject, iTween.Hash(
                    "amount", new Vector3(0, 1, 1),
                    "time", 0.75f));
                //NPC 撞飛
                iTween.MoveTo(NPCTalkingManager.script.CurrentTalkingData.NPCObject, iTween.Hash(
                    "x", NPCTalkingManager.script.CurrentTalkingData.NPCObject.transform.position.x - 4,
                    "time", 0.75f));

                //產生碰撞音效
                this.audio.PlayOneShot(this.碰撞音效);
                //動作佇列 (卡片掉->Idle2)
                NPCTalkingManager.script.CurrentTalkingData.NPCObject.GetComponent<SmoothMoves.BoneAnimation>().Play("carddrop");
                NPCTalkingManager.script.CurrentTalkingData.NPCObject.GetComponent<SmoothMoves.BoneAnimation>().PlayQueued("idle2");
            }
            else
                NPCTalkingManager.script.NextTalk();
        }
    }
}