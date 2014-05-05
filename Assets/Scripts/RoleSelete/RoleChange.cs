using UnityEngine;
using System.Collections;

public class RoleChange : MonoBehaviour
{
    public ChangeDirection Direction;

    void OnMouseDown()
    {
        print(this.Direction);

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
