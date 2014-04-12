﻿using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public float MoveTime;
    public float DelayTime;
    public bool isStartMove;
    public iTween.EaseType easeType;

    // Use this for initialization
    void Start()
    {
        if (this.isStartMove)
            this.Move();
    }

    public void Move()
    {
        this.transform.position = this.StartPoint;
        iTween.MoveTo(this.gameObject, iTween.Hash("position", this.EndPoint, "time", this.MoveTime, "delay", this.DelayTime, "easetype", this.easeType));
    }
}