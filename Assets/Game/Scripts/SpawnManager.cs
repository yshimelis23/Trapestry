using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    private static SpawnManager _Instance;

    void Awake()
    {
        _Instance = this;
    }

    public SurfaceTracker surfaceTracker;

    public GameObject startAreaPrefab;
    public GameObject goalAreaPrefab;

    //List of GameObjects that can be spawned
    public List<GameObject> ListOfSpawnableObjects;

    [HideInInspector]
    public ModalObject objectToPlace;
    [HideInInspector]
    public ModalObject objectToGiveLookPoint;

    public GameObject nodeCursorPrefab;
    private GameObject currentNodeCursor;

    // Update is called once per frame
    void Update () {
        bool canPlaceHere = (surfaceTracker.mTargetSurface == PlacementSurface.Invalid) ? false : true;

        if (objectToPlace != null)
        {
            objectToPlace.transform.position = surfaceTracker.targetPosition;
            objectToPlace.transform.rotation = Quaternion.LookRotation(surfaceTracker.normal);
            objectToPlace.SetColor(canPlaceHere ? Color.green : Color.red);
        }

        if(objectToGiveLookPoint != null)
        {
            currentNodeCursor.transform.position = surfaceTracker.targetPosition;
            currentNodeCursor.transform.rotation = Quaternion.LookRotation(surfaceTracker.normal);
            objectToGiveLookPoint.SetSecondNode(currentNodeCursor);
        }
    }

    private ContainsTracker start;
    private ContainsTracker goal;

    public void SpawnGoal()
    {
        if (goal != null)
        {
            Destroy(goal.gameObject);
        }
        ContainsTracker tracker = StartSpawningObject(goalAreaPrefab).GetComponent<ContainsTracker>();
        tracker.SetAsGoal();
        goal = tracker;
    }

    public void SpawnStart()
    {
        if(start != null)
        {
            Destroy(start.gameObject);
        }
        ContainsTracker tracker = StartSpawningObject(startAreaPrefab).GetComponent<ContainsTracker>();
        tracker.SetAsStart();
        start = tracker;
    }

    //Spawn Objects in the ListoFSpawnable Objects. Pass in IndexNumber of the Object.
    private void SpawnObject(int IndexNumber)
    {
        StartSpawningObject(ListOfSpawnableObjects[IndexNumber]).GetComponent<ModalObject>();
    }

    private GameObject StartSpawningObject(GameObject objectRef)
    {
        //Right Now it spawns to right of the player.
        GameObject newObj = Instantiate(objectRef, surfaceTracker.targetPosition, Quaternion.identity) as GameObject;
        newObj.GetComponent<ModalObject>().Initialize();
        StartPlacingObject(newObj.GetComponent<ModalObject>());
        return newObj;
    }

    public void StartPlacingObject(ModalObject obj)
    {
        objectToPlace = obj;
        objectToPlace.SetState(ModalObject.PlacementState.MOVING);
        objectToPlace.Deselected();
    }

    public void ObjectPlaced()
    {
        objectToPlace.SetState(ModalObject.PlacementState.PLACED);
        SelectionManager.Instance.ObjectSelected(objectToPlace);
        objectToPlace = null;
    }

    public void StartNode(ModalObject obj)
    {
        objectToGiveLookPoint = obj;
        objectToGiveLookPoint.Deselected();
        currentNodeCursor = Instantiate(nodeCursorPrefab);
    }

    public void NodePlaced()
    {
        Destroy(currentNodeCursor);
        objectToGiveLookPoint = null;
    }

    public void Tap()
    {
        if(objectToPlace != null)
        {
            ObjectPlaced();
        }
    }

}
