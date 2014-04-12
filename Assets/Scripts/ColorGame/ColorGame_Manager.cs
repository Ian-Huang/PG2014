using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorGame_Manager : MonoBehaviour
{
    public string word;

    public Rect rect;
    public List<ColorData> ColorDataList;

    public GUIStyle style;

    private int currentColorNameIndex = -1;
    private int currentColorValueIndex = -1;

    public static ColorGame_Manager script;

    // Use this for initialization
    void Start()
    {
        this.NextWord();
    }

    void NextWord()
    {
        int nameNum;
        do
        {
            nameNum = Random.Range(0, this.ColorDataList.Count);
        } while (nameNum == this.currentColorNameIndex || nameNum == this.currentColorValueIndex);
        this.currentColorNameIndex = nameNum;

        int valueNum;
        do
        {
            valueNum = Random.Range(0, this.ColorDataList.Count);
        } while (valueNum == this.currentColorNameIndex || valueNum == this.currentColorValueIndex);
        this.currentColorValueIndex = valueNum;

        this.word = this.ColorDataList[this.currentColorNameIndex].ColorName;
        this.style.normal.textColor = this.ColorDataList[this.currentColorValueIndex].ColorValue;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * rect.x, Screen.height * (rect.y - 0.5f), Screen.width * rect.width, Screen.height * rect.height), this.word, this.style);
        if (GUI.Button(new Rect(Screen.width * rect.x, Screen.height * rect.y, Screen.width * rect.width, Screen.height * rect.height), "下一個"))
        {
            this.NextWord();
        }
    }

    [System.Serializable]
    public class ColorData
    {
        public string ColorName;
        public Color ColorValue;
    }

    void Awake()
    {
        script = this;
    }
}
