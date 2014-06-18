﻿using UnityEngine;
using System.Collections;

//[ExecuteInEditMode] 
public class DialogName : MonoBehaviour
{
    public GameDefinition.DialogName dialogName;

    public float DelayTime;

    void OnEnable()
    {
        StartCoroutine(NameShow());
    }

    // Use this for initialization
    IEnumerator NameShow()
    {
        this.GetComponent<TextMesh>().text = "";
        yield return new WaitForSeconds(this.DelayTime);

        switch (this.dialogName)
        {
            case GameDefinition.DialogName.None:
                break;
            case GameDefinition.DialogName.被選角色名:
                this.GetComponent<TextMesh>().text = GameDefinition.PlayerNameData[GameDefinition.CurrentChoosePlayerName];
                break;
            default:
                this.GetComponent<TextMesh>().text = this.dialogName.ToString();
                break;
        }
    }
}