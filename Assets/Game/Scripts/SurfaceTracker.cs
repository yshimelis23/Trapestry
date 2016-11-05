using UnityEngine;
using System.Collections;

public enum PlacementSurface { Invalid, Wall, Floor, Ceiling };

public class SurfaceTracker : MonoBehaviour
{
    public Vector3 targetPosition;
    public PlacementSurface mTargetSurface = PlacementSurface.Invalid;

    //For debug:
    public GameObject TestCursor;
    public Vector3 normal;
    Color floor = Color.green;
    Color wall = Color.yellow;
    Color ceiling = Color.blue;
    Color invalid = Color.red;

    public LayerMask raycastLayers;

    public float gazeDistance = 15f;

    // Use this for initialization
    void Start()
    {
        if (TestCursor == null)
        {
            TestCursor = GameObject.Find("TestCursor");
        }
        //start off assuming you're lookin at a wall
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Camera.main.transform.position;
        Vector3 gazeDir = Camera.main.transform.forward;
        RaycastHit info;
        // check player's line of sight for a wall
        if (Physics.Raycast(new Ray(playerPos, gazeDir), out info, gazeDistance, raycastLayers, QueryTriggerInteraction.Ignore))
        {
            targetPosition = info.point;
            normal = info.normal;
            TestCursor.transform.position = targetPosition;
            TestCursor.GetComponent<Renderer>().material.color = wall;
            //check the normal of the surface and change color to show type
            if (Mathf.Abs(Vector3.Dot(Vector3.up, info.normal)) < 0.5f)
            {
                TestCursor.GetComponent<Renderer>().material.color = wall;
                mTargetSurface = PlacementSurface.Wall;
            }
            else if (Vector3.Dot(Vector3.up, info.normal) > 0)
            {
                TestCursor.GetComponent<Renderer>().material.color = ceiling;
                mTargetSurface = PlacementSurface.Ceiling;
            }
            else if (Vector3.Dot(Vector3.up, info.normal) < 0)
            {
                TestCursor.GetComponent<Renderer>().material.color = floor;
                mTargetSurface = PlacementSurface.Floor;
            }
            else
            {
                TestCursor.GetComponent<Renderer>().material.color = invalid;
                mTargetSurface = PlacementSurface.Invalid;
            }
        }

    }
}
