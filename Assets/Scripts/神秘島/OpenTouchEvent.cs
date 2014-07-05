using UnityEngine;
using System.Collections;

public class OpenTouchEvent : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        foreach (TreasureController script in GameObject.FindObjectsOfType<TreasureController>())
        {
            script.isCanTouch = true;
        }

        foreach (NPC script in GameObject.FindObjectsOfType<NPC>())
        {
            script.isCanTouch = true;
        }
    }
}