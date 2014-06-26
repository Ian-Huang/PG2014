using UnityEngine;
using System.Collections;

public class AutoNextGameStep : MonoBehaviour
{
    public float NextStepTime;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(this.NextStepTime);
        GameCollection.script.NextGameStep();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
