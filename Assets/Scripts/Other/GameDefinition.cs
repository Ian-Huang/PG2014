﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDefinition
{
    //人物選擇交換時間
    public const float CardChangeTime = 0.5f;

    //最小遊戲人數
    public const int MinPlayerCount = 4;

    //紀錄人物名字，與其對應的角色 <參數預設名字，測試使用>
    public static Dictionary<SystemPlayerName, string> PlayerNameData = new Dictionary<SystemPlayerName, string>() {
        {SystemPlayerName.翠絲,"翠絲"} , {SystemPlayerName.巴洛,"巴洛"} , {SystemPlayerName.卡勒b,"卡勒b"},
        {SystemPlayerName.里昂,"里昂"} , {SystemPlayerName.莉莉卡,"莉莉卡"} , {SystemPlayerName.葛蘭蒂,"葛蘭蒂"}};

    //按鈕事件
    public enum ButtonEvent
    {

        //角色選擇場景
        SureButton_RoleSelect = 1000, LeftArrow_RoleSelect = 1001, RightArrow_RoleSelect = 1002
    }

    public enum SystemPlayerName
    {
        翠絲, 巴洛, 卡勒b, 里昂, 莉莉卡, 葛蘭蒂
    }

    public enum DialogName
    {
        None = 0,

        //主角群----
        翠絲 = 11, 巴洛 = 12, 卡勒b = 13, 里昂 = 14, 莉莉卡 = 15, 葛蘭蒂 = 16,

        //NPC----
        卡片收集者 = 21, 知識通 = 22, 警長 = 23, 小偷 = 24, //第一座島嶼
        貪吃鬼 = 31, 甜點師 = 32, 老船長 = 33, 美人魚 = 34, 醫生 = 35, 病人 = 36, //第二座島嶼
        小畫家 = 41, 著名歌手 = 42, 音樂家 = 43, 村長 = 44 //第三座島嶼
    }
}