using UnityEngine;
using System.Collections;

public class RoleChange : MonoBehaviour
{
    public ChangeDirection Direction;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum ChangeDirection
    {
        Left = 1, Right = 2
    }
}
