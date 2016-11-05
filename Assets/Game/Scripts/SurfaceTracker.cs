﻿using UnityEngine;
using System.Collections;

enum PlacementSurface { Invalid, Wall, Floor, Ceiling };

public class SurfaceTracker : MonoBehaviour
{

    public Vector3 toPlacePosition;
    //For debug:
    public GameObject TestCursor;
    public Vector3 normal;
    PlacementSurface mTargetSurface;
    Color floor = Color.green;
    Color wall = Color.yellow;
    Color ceiling = Color.blue;
    Color invalid = Color.red;

    // Use this for initialization
    void Start()
    {

        //start off assuming you're lookin at a wall

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Camera.main.transform.position;
        Vector3 gazeDir = Camera.main.transform.forward;
        RaycastHit info;
        // check player's line of sight for a wall
        if (Physics.Raycast(playerPos, gazeDir, out info))
        {
            toPlacePosition = info.point;
            normal = info.normal;
            TestCursor.transform.position = toPlacePosition;
            TestCursor.GetComponent<Renderer>().material.color = wall;
            //check the normal of the surface and change color to show type
            if (info.normal.z <= -.86f)
            {
                TestCursor.GetComponent<Renderer>().material.color = wall;
                mTargetSurface = PlacementSurface.Wall;
            }
            else if (info.normal.y <= -.86f)
            {
                TestCursor.GetComponent<Renderer>().material.color = ceiling;
                mTargetSurface = PlacementSurface.Ceiling;
            }
            else if (info.normal.y >= .86f)
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