using UnityEngine;
using System.Collections;

public class SpriteColorTo : MonoBehaviour
{
    public Color StartColor = new Color(1, 1, 1, 1);
    public Color EndColor = new Color(1, 1, 1, 1);
    public float ChangeTime;
    public float DelayTime;
    public bool isStartChange;
    public iTween.EaseType easeType;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
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
