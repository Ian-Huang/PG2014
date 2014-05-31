using UnityEngine;
using System.Collections;

//[ExecuteInEditMode] 
public class DialogName : MonoBehaviour
{
    public GameDefinition.DialogName dialogName;

    public float DelayTime;

    // Use this for initialization
    IEnumerator Start()
    {
        this.GetComponent<TextMesh>().text = "";
        yield return new WaitForSeconds(this.DelayTime);

        if (this.dialogName != GameDefinition.DialogName.None)
            this.GetComponent<TextMesh>().text = this.dialogName.ToString();

        switch (this.dialogName)
        {
            case GameDefinition.DialogName.None:
                break;
            case GameDefinition.DialogName.被選角色名:
                this.GetComponent<TextMesh>().text = GameDefinition.CurrentChoosePlayerName.ToString();
                break;
            default:
                this.GetComponent<TextMesh>().text = this.dialogName.ToString();
                break;
        }
    }
}