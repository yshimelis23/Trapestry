using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public GameObject startArea;
    public GameObject goalArea;

    //List of GameObjects that can be spawned
    public List<GameObject> ListOfSpawnableObjects;

    public void SpawnGoal()
    {
        SpawnArbitraryObject(goalArea);
    }

    public void SpawnStart()
    {
        SpawnArbitraryObject(startArea);
    }


    //Spawn Objects in the ListoFSpawnable Objects. Pass in IndexNumber of the Object.
    public void SpawnObject(int IndexNumber)
    {
        SpawnArbitraryObject(ListOfSpawnableObjects[IndexNumber]);
    }

    private void SpawnArbitraryObject(GameObject objectRef)
    {
        Instantiate(objectRef, Camera.main.transform.position + new Vector3(2, 0, 0), Quaternion.identity);//Right Now it spawns to right of the player.
    }
}
