using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public GameObject startArea;
    public GameObject goalArea;

    //List of GameObjects that can be spawned
    public List<GameObject> ListOfSpawnableObjects;

    private ContainsTracker start;
    private ContainsTracker goal;

    public void SpawnGoal()
    {
        if (goal != null)
        {
            Destroy(goal.gameObject);
        }
        ContainsTracker tracker = SpawnArbitraryObject(goalArea).GetComponent<ContainsTracker>();
        tracker.SetAsGoal();
        goal = tracker;
    }

    public void SpawnStart()
    {
        if(start != null)
        {
            Destroy(start.gameObject);
        }
        ContainsTracker tracker = SpawnArbitraryObject(startArea).GetComponent<ContainsTracker>();
        tracker.SetAsStart();
        start = tracker;
    }

    //Spawn Objects in the ListoFSpawnable Objects. Pass in IndexNumber of the Object.
    public void SpawnObject(int IndexNumber)
    {
        SpawnArbitraryObject(ListOfSpawnableObjects[IndexNumber]);
    }

    private GameObject SpawnArbitraryObject(GameObject objectRef)
    {
        //Right Now it spawns to right of the player.
        return Instantiate(objectRef, Camera.main.transform.position + new Vector3(0, 0, 2), Quaternion.identity) as GameObject;
    }
}
