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

    private float placeObjectStartTime;

    // Update is called once per frame
    void Update () {
        bool canPlaceHere = (surfaceTracker.mTargetSurface == PlacementSurface.Invalid) ? false : true;

        if (objectToPlace != null)
        {
            objectToPlace.PlaceOnSurface(surfaceTracker.targetPosition, surfaceTracker.normal);
            objectToPlace.SetColor(canPlaceHere ? new Color(0,1,0,0.5f) : new Color(0, 1, 0, 0.5f));
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

        UIManager.Instance.GoalInstruction();

        if(goal != null && start != null)
        {
            UIManager.Instance.EnablePlayButton();
        }
        else
        {
            UIManager.Instance.DisablePlayButton();
        }
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

        UIManager.Instance.StartInstruction();

        if (goal != null && start != null)
        {
            UIManager.Instance.EnablePlayButton();
        }
        else
        {
            UIManager.Instance.DisablePlayButton();
        }
    }

    public void SpawnLaser()
    {
        SpawnObject(0);
        UIManager.Instance.LaserInstruction();
    }

    public void SpawnLava()
    {
        SpawnObject(1);
        UIManager.Instance.LavaInstruction();
    }

    public void SpawnTrap()
    {
        SpawnObject(2);
        UIManager.Instance.TrapInstruction();
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
        SelectionManager.Instance.DeselectAll();
        objectToPlace = obj;
        objectToPlace.SetState(ModalObject.PlacementState.MOVING);
        placeObjectStartTime = Time.time;
        UIManager.Instance.DisablePlacementMenu();
    }

    public void ObjectPlaced()
    {
        if (objectToPlace.IsValidSurface(surfaceTracker.mTargetSurface))
        {
            objectToPlace.SetState(ModalObject.PlacementState.PLACED);
            SelectionManager.Instance.ObjectSelected(objectToPlace);
            objectToPlace = null;
            UIManager.Instance.EnablePlacementMenu();
            UIManager.Instance.HideInstructions();
        }
        else
        {
            // play sound
        }
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
        if(objectToPlace != null && Time.time - placeObjectStartTime > 0.5f)
        {
            ObjectPlaced();
        }
    }

}
