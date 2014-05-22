using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventCollection : MonoBehaviour
{
    public List<GameObject> EventList;
    public int CurrentEventIndex;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject temp in this.EventList)
            temp.SetActive(false);

        this.EventList[this.CurrentEventIndex].SetActive(true);
    }

    public void NextEvent()
    {
        this.EventList[this.CurrentEventIndex].SetActive(false);
        this.CurrentEventIndex++;
        this.EventList[this.CurrentEventIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(100, 100, 100, 100), "Test"))
    //    {
    //        this.NextEvent();
    //    }
    //}
}
