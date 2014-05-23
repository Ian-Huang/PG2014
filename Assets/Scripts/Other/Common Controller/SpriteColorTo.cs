﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 通用函式，Sprite Color 漸變控制
/// </summary>
public class SpriteColorTo : MonoBehaviour
{
    public Color StartColor = new Color(1, 1, 1, 1);    //起始顏色
    public Color EndColor = new Color(1, 1, 1, 1);      //結束顏色
    public float ChangeTime;                            //過程花費時間
    public float DelayTime;                             //延遲
    public bool isStartChange;
    public iTween.EaseType easeType;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        //是否在物件被啟用時啟動函式
        if (this.isStartChange)
            this.ColorTo();
    }

    public void ColorTo()
    {
        this.spriteRenderer.color = this.StartColor;

        iTween.ValueTo(this.gameObject, iTween.Hash(
                "from", this.StartColor,
                "to", this.EndColor,
                "time", this.ChangeTime,
                "delay", this.DelayTime,
                "onupdate", "ColorUpdate",
                "oncomplete", "ColorComplete",
                "easetype", this.easeType));
    }

    void ColorUpdate(Color color)
    {
        this.spriteRenderer.color = color;
    }

    void ColorComplete()
    {

    }
}
