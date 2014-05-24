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
                RoleSelectController.script.SavePlayerNameToSystem();
                break;
            case GameDefinition.ButtonEvent.RightArrow_RoleSelect:
                RoleSelectController.script.RunRightCard();
                break;
            case GameDefinition.ButtonEvent.LeftArrow_RoleSelect:
                RoleSelectController.script.RunLeftCard();
                break;

            default:
                break;
        }
    }
}