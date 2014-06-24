using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissionSelectCollection : MonoBehaviour
{
    public List<IslandMissionInfo> IslandMissionList;

    public IslandMissionInfo CurrentIslandMissionInfo;

    // Use this for initialization
    void Start()
    {
        this.CurrentIslandMissionInfo = this.IslandMissionList.Find((IslandMissionInfo data) =>
        {
            if (data.Island == GameDefinition.CurrentIsland)
                return true;
            else
                return false;
        });

        if (!GameDefinition.MissionActiveStateMapping[this.CurrentIslandMissionInfo.MainMission])
        {
            foreach (NPC tempScript in this.CurrentIslandMissionInfo.IslandNPCs.GetComponentsInChildren<NPC>())
            {
                if (tempScript.Mission != this.CurrentIslandMissionInfo.MainMission)
                    tempScript.gameObject.SetActive(false);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public class IslandMissionInfo
    {
        public GameDefinition.Island Island;
        public GameObject IslandNPCs;
        public GameDefinition.Mission MainMission;
        public List<MissionRelation> MissionRelations;
    }

    [System.Serializable]
    public class MissionRelation
    {
        public GameDefinition.Mission SetMission;
        public GameDefinition.Mission PredecessorMission;
    }
}
