using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    //List of GameObjects that can be spawned
    public List<GameObject> ListOfSpawnableObjects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnLazer()
    {

        
    }


    //Spawn Objects in the ListoFSpawnable Objects. Pass in IndexNumber of the Object.
    public void SpawnObject(int IndexNumber)
    {

        Instantiate(ListOfSpawnableObjects[IndexNumber], Camera.main.transform.position + new Vector3(2, 0, 0), Quaternion.identity);//Right Now it spawns to right of the player.
    }

}
