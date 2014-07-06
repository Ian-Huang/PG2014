using UnityEngine;
using System.Collections;

public class Skake : MonoBehaviour
{
    public GameObject ShakeObject;
    public float ShakeTime;
    public Vector3 ShakeAmount;

    public bool isStartShake;

    // Use this for initialization
    void Start()
    {
        if (this.isStartShake)
        {
            //鏡頭震動
            iTween.ShakePosition(this.ShakeObject, iTween.Hash(
                "amount", this.ShakeAmount,
                "time", this.ShakeTime));
        }
    }
}