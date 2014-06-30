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
    public static SystemPlayerName CurrentChoosePlayerName = SystemPlayerName.莉莉卡;

    //紀錄目前選擇的任務
    public static Mission CurrentChooseMission = Mission.None;
    //紀錄目前選擇的遊戲類型
    public static GameType CurrentChooseGameType = GameType.None;

    //紀錄目前進行到的島嶼
    public static Island CurrentIsland = Island.莎吉斯島;

    //任務被觸發的狀況 false = 未進行該任務 <目前為預設值>
    public static Dictionary<Mission, bool> MissionActiveStateMapping = new Dictionary<Mission, bool>() { 
        //(智慧)莎吉斯島
        {Mission.卡片掉了,false} ,{Mission.黃綠紅,false},{Mission.知識通,false},{Mission.推理要在晚餐後,true},{Mission.消失的羅盤,false},
        //(勇氣)布列德島
        {Mission.奶油水果派,false} ,{Mission.給我食譜,false},{Mission.我的船壞了,false},{Mission.在我的歌聲裡,true},{Mission.你怎麼連話都說不清楚,false},
        //(自信)康費爾森島
        {Mission.我要成為畢卡索,false} ,{Mission.筆墨登場,false},{Mission.你是我的眼,false},{Mission.未填詞,false},{Mission.混亂的程序,false}};

    public static List<QuickAnsGameQuestionData> QuickAnsGameQuestionDataList_isUsed = new List<QuickAnsGameQuestionData>();
    public static List<QuickAnsGameQuestionData> QuickAnsGameQuestionDataList = new List<QuickAnsGameQuestionData>()
    {
        new QuickAnsGameQuestionData("最後一位蘇聯領導人，推動政策改革，結束了全世界的冷戰對峙局面，此人是？","戈巴契夫","史達林","列寧",1),
        new QuickAnsGameQuestionData("有「經營之神」稱號，並且與池田先生對談，兩人的對談集《人生問答》，請問他是誰？","安藤忠雄","松下幸之助","安倍晉三",2),
        new QuickAnsGameQuestionData("曾與池田先生對話，因為拒絕在巴士上讓座給白人，點燃了美國拒乘巴士的聯合抵制運動，此位黑人女性是？","J.K.羅琳","羅莎‧帕克斯","碧昂絲",2),
        new QuickAnsGameQuestionData("曾與池田先生對話，南非首位黑人總統，以非暴力行動促進種族和解，此人是？","甘地","錢德拉","曼德拉",3),
        new QuickAnsGameQuestionData("因為生活中開心的事情而獲得短暫的快樂，是「十界」中的哪一界？","畜生界","天界","人界",2),
        new QuickAnsGameQuestionData("以自我為中心，好勝心強烈，是「十界」中的哪一界？","修羅界","聲聞界","畜生界",1),
        new QuickAnsGameQuestionData("形容接受此一信仰容易，但要能堅持信心卻是難上加難。","受易持難","佛法西還","依正不二",1),
        new QuickAnsGameQuestionData("對所有人都極為尊敬，不輕視任何人，此一做人的良好態度，就如同？","諸天善神","觀世音菩薩","常不輕菩薩",3),
        new QuickAnsGameQuestionData("下列何者是象徵學問、思想的菩薩？","妙音菩薩","藥王菩薩","普賢菩薩",3),
        new QuickAnsGameQuestionData("我們自己的環境是歡喜、明朗的世界，抑或是充滿苦惱、污穢的世界，全取決於自己的生命狀態；下列何者正是描述此一道理？","一生成佛","依正不二","三障四魔",2),
        new QuickAnsGameQuestionData("貫徹信心的人， 必定會以各種的人事物的姿態出現在身活周遭，守護法華經的行者。","地涌菩薩","諸天善神","三類強敵",2),
        new QuickAnsGameQuestionData("2014年世界盃足球賽在下列哪個國家舉辦？","西班牙","阿根廷","巴西",3),
        new QuickAnsGameQuestionData("戰國末年，楚國詩人屈原因為感到救國無望，在絕望和悲憤之下懷大石跳進哪條河川？","黃河","汨羅江","淮河",2),
        new QuickAnsGameQuestionData("是誰提出行星運動三定律","哥白尼","克卜勒","伽利略",2),
        new QuickAnsGameQuestionData("小說「新人間革命」中，山本伸一是誰的化名？","牧口常三郎","戶田城聖","池田大作",3),
        new QuickAnsGameQuestionData("以下何者不是鉛筆的成份？","石墨","鉛","黏土",1),
        new QuickAnsGameQuestionData("以下哪種電器不需要變壓器？","電腦","電風扇","手機充電器",2),
        new QuickAnsGameQuestionData("國際商業機器公司，藍色巨人","IBM","Intel","Apple",1),
        new QuickAnsGameQuestionData("撲克牌中每個花色的K都代表著歷史上偉大的君王，黑桃是大衛王，梅花是亞歷山大大地，紅桃是查理大帝，方塊是？","亞瑟王","凱撒大帝","秦始皇",2),
        new QuickAnsGameQuestionData("歷史上有名的諾曼地戰役發生在哪個國家？","德國","法國","英國",2),
        new QuickAnsGameQuestionData("三國演義中「臥龍鳳雛，得一可安天下」，其中「鳳雛」指的是誰？","諸葛亮","周瑜","龐統",3),
        new QuickAnsGameQuestionData("以下哪個不是電腦容量單位？","KB","GB","FB",3),
        new QuickAnsGameQuestionData("以下何者不是正義聯盟的成員？","布魯思·偉恩","克拉克·肯特","史蒂芬·羅傑斯",3),
        new QuickAnsGameQuestionData("以下何者不是復仇者聯盟的成員？","東尼·史塔克","金剛狼","雷神·索爾",2),
        new QuickAnsGameQuestionData("哆啦A夢是出自哪位漫畫家之手？","藤子·F·不二雄","臼井儀人","尾田榮一郎",1),
        new QuickAnsGameQuestionData("哪一種動物不會進行無性生殖？","蝸牛","蜜蜂","草履蟲",1),
        new QuickAnsGameQuestionData("創價學會創辦之日是哪一天","3.16","11.18","5.3",2)
    };

    public static List<string> HandSomethingGameQuestionList_isUsed = new List<string>();
    public static List<string> HandSomethingGameQuestionList = new List<string>() 
    {
       "皇天不負苦心人","陰溝裡翻船","冰雪奇緣","哥吉拉","駭客","派大星","宮保雞丁","福運","人間革命","熊大","晴天霹靂","熱氣球","洗衣機","樂高","按摩椅","鳳雛","透心涼","海賊王"
    };

    //按鈕事件
    public enum ButtonEvent
    {
        //角色選擇場景
        SureButton_RoleSelect = 1000, LeftArrow_RoleSelect = 1001, RightArrow_RoleSelect = 1002,

        //區域地圖場景
        MissionSure_Area = 2000, MissionCancel_Area = 2001,
        NextGameStep = 3000,
        GameEnd = 4000, GameEnd_卡片掉了 = 4001,
        HandSomethingGame_Correct = 5000, HandSomethingGame_Giveup = 5001
    }

    public enum SystemPlayerName
    {
        翠絲, 巴洛, 卡勒b, 里昂, 莉莉卡, 葛蘭蒂
    }

    public enum DialogName
    {
        None = 0, 被選角色名 = 1,

        //主角群----
        翠絲 = 11, 巴洛 = 12, 卡勒b = 13, 里昂 = 14, 莉莉卡 = 15, 葛蘭蒂 = 16,

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
        卡片掉了 = 11, 黃綠紅 = 12, 知識通 = 13, 推理要在晚餐後 = 14, 消失的羅盤 = 15,    //關鍵任務：推理要在晚餐後

        //(勇氣)布列德島
        奶油水果派 = 21, 給我食譜 = 22, 我的船壞了 = 23, 在我的歌聲裡 = 24, 你怎麼連話都說不清楚 = 25,    //關鍵任務：你怎麼連話都說不清楚

        //(自信)康費爾森島
        我要成為畢卡索 = 31, 筆墨登場 = 32, 你是我的眼 = 33, 未填詞 = 34, 混亂的程序 = 35   //關鍵任務：混亂的程序
    }

    /// <summary>
    /// 遊戲種類
    /// </summary>
    public enum GameType
    {
        None = 0,
        記憶對對碰 = 1, 顏不及意 = 2, 快問快答 = 3, 推理要在晚餐後 = 4, 支援前線 = 5,
        大家來找碴 = 6, 歌喉戰 = 7, 比手畫腳 = 8, 人人都是畢卡索 = 9, 排列組合 = 10
    }

    public enum Island
    {
        莎吉斯島 = 1, 布列德島 = 2, 康費爾森島 = 3
    }

    public class QuickAnsGameQuestionData
    {
        public string QuestionText;

        public string OptionText1;
        public string OptionText2;
        public string OptionText3;

        public int TrueAnswer;
        public QuickAnsGameQuestionData(string question, string option1, string option2, string option3, int trueAnswer)
        {
            this.QuestionText = question;
            this.OptionText1 = option1;
            this.OptionText2 = option2;
            this.OptionText3 = option3;
            this.TrueAnswer = trueAnswer;
        }
    }

    [System.Serializable]
    public class RoleData
    {
        public SystemPlayerName SystemName;  //方便辨識，系統名稱
        public GameObject RoleObject;   //腳色動畫物件
    }
}