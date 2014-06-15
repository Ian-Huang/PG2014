using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraChangeBackground : MonoBehaviour
{
    public List<BackgroundData> BackgroundDataList;
    public GameObject BackgroundObject;
    public float X_SetPoint;

    public void ToMissionBackground()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(
                 "x", this.X_SetPoint,
                 "time", 1.5f
                 ));
    }

    void Start()
    {
        }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public class BackgroundData
    {
        public GameDefinition.Mission Mission;
        public Sprite sprite;
    }
}
