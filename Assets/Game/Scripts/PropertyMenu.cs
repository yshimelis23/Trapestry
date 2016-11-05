using UnityEngine;
using System;

public class PropertyMenu : MonoBehaviour
{
    public event Action placeNewLookPoint;
    public event Action destroyObject;
    public event Action moveObject;

    public void TriggerNewLookPoint()
    {
        if(placeNewLookPoint != null)
        {
            placeNewLookPoint.Invoke();
        }
    }

    public void TriggerDestroy()
    {
        if (destroyObject != null)
        {
            destroyObject.Invoke();
        }
    }

    public void TriggerMoveObject()
    {
        if (moveObject != null)
        {
            moveObject.Invoke();
        }
    }
}
