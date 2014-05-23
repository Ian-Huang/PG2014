using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public GameDefinition.ButtonEvent buttonEvent;

    void OnMouseUpAsButton()
    {
        switch (this.buttonEvent)
        {
            case GameDefinition.ButtonEvent.SureButton_RoleSelect:
                RoleSelectController.script.CenterCard.gameObject.GetComponentInChildren<TextMesh>().text = GameObject.FindObjectOfType<RoleNameEnter>().EnterNameString;
                break;

            default:
                break;
        }
    }
}