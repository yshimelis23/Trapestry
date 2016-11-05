using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    //List of GameObjects that can be spawned
    public List<GameObject> ListOfSpawnableObjects;
    public bool canPlaceHere;
    public GameObject Laser;
    public SurfaceTracker mSurfaceTracker;
    public ModalObject toBePlaced;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        canPlaceHere = (mSurfaceTracker.mTargetSurface == PlacementSurface.Invalid) ? false : true;
        if (toBePlaced != null)
        {
            toBePlaced.transform.position = mSurfaceTracker.targetPosition;
            toBePlaced.GetComponent<Renderer>().material.color = canPlaceHere ? Color.green : Color.red;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Callign Onsleedect");
            toBePlaced.OnSelect();
        }
    }

    public void SpawnLazer()
    {
        if (mSurfaceTracker.mTargetSurface != PlacementSurface.Invalid && toBePlaced == null)
        {
            GameObject obj = Instantiate(Laser, mSurfaceTracker.targetPosition, Quaternion.LookRotation(mSurfaceTracker.normal)) as GameObject;
            obj.GetComponent<Collider>().enabled = false;
            toBePlaced = obj.GetComponent<ModalObject>();
            toBePlaced.mSpawnManager = this;
        }
        else if (toBePlaced != null)
        {
            Debug.Log("Finish Placing current object before making more");
        }
    }


    //Spawn Objects in the ListoFSpawnable Objects. Pass in IndexNumber of the Object.
    private void SpawnObject(int IndexNumber)
    {

        //Instantiate(ListOfSpawnableObjects[IndexNumber], Camera.main.transform.position + new Vector3(2, 0, 0), Quaternion.identity);//Right Now it spawns to right of the player.
        Instantiate(ListOfSpawnableObjects[IndexNumber], mSurfaceTracker.targetPosition, Quaternion.identity);
    }

    public void ObjectPlaced()
    {
        toBePlaced = null;
    }

}
