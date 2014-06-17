using UnityEngine;
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

    //紀錄目前被選擇的腳色<參數預設，測試使用>
    public static SystemPlayerName CurrentChoosePlayerName = SystemPlayerName.翠絲;

    //紀錄目前選擇的任務
    public static Mission CurrentChooseMission = Mission.None;
    //紀錄目前選擇的遊戲類型
    public static GameType CurrentChooseGameType = GameType.None;


    //按鈕事件
    public enum ButtonEvent
    {
        //角色選擇場景
        SureButton_RoleSelect = 1000, LeftArrow_RoleSelect = 1001, RightArrow_RoleSelect = 1002,

        //區域地圖場景
        MissionSure_Area = 2000, MissionCancel_Area = 2001,
        GameStart = 2002
        
    }

    public enum SystemPlayerName
    {
        翠絲, 巴洛, 卡勒b, 里昂, 莉莉卡, 葛蘭蒂
    }

    public enum DialogName
    {
        None = 0, 被選角色名 = 1,

        //主角群----
        //翠絲 = 11, 巴洛 = 12, 卡勒b = 13, 里昂 = 14, 莉莉卡 = 15, 葛蘭蒂 = 16,

        //NPC----
        卡片收集者 = 21, 知識通 = 22, 警長 = 23, 小偷 = 24, //第一座島嶼
        貪吃鬼 = 31, 甜點師 = 32, 老船長 = 33, 美人魚 = 34, 醫生 = 35, 病人 = 36, //第二座島嶼
        小畫家 = 41, 著名歌手 = 42, 音樂家 = 43, 村長 = 44 //第三座島嶼
    }

    /// <summary>
    /// 任務種類
    /// </summary>
    public enum Mission
    {
        None = 0,
        //(智慧)莎吉斯島
        卡片掉了 = 11, 黃綠紅 = 12, 知識通 = 13, 推理要在晚餐後 = 14, 消失的羅盤 = 15,

        //(勇氣)布列德島
        奶油水果派 = 21, 給我食譜 = 22, 我的船壞了 = 23, 在我的歌聲裡 = 24, 你怎麼連話都說不清楚 = 25,

        //(自信)康費爾森島
        我要成為畢卡索 = 31, 筆墨登場 = 32, 你是我的眼 = 33, 未填詞 = 34, 混亂的程序 = 35
    }

    /// <summary>
    /// 遊戲種類
    /// </summary>
    public enum GameType
    {
        None = 0,
        記憶對對碰 = 1, 顏不及意 = 2, 快問快答 = 3, 推理要在晚餐後 = 4, 支援前線 = 5,
        大家來找碴 = 6, 歌喉戰 = 7, 比手畫腳 = 8, 人人都是畢卡索 = 9, 團體戰 = 10
    }
}