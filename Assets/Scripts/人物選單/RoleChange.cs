using UnityEngine;
using System.Collections;

public class RoleChange : MonoBehaviour
{
    public ChangeDirection Direction;

    public Sprite NormalSprite;
    public Sprite ActiveSprite;

    void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().sprite = this.ActiveSprite;
    }

    void OnMouseUp()
    {
        this.GetComponent<SpriteRenderer>().sprite = this.NormalSprite;
    }

    void OnMouseUpAsButton()
    {
        if (this.Direction == ChangeDirection.Right)
        {
            RoleSelectController.script.RunRightCard();
        }
        else
        {
            RoleSelectController.script.RunLeftCard();
        }
    }

    // Use this for initialization
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = this.NormalSprite;
    }

    public enum ChangeDirection
    {
        Left = 1, Right = 2
    }
}
