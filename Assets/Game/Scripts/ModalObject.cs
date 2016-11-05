using UnityEngine;
using System.Collections;

public class ModalObject : MonoBehaviour
{
    enum PlacementState { PLACED, MOVING};
    public SpawnManager mSpawnManager;//halfasdsed attempt at good code
    private PlacementState mPlacementState = PlacementState.MOVING;
    private bool _isPlayMode = false;
    public bool isPlayMode
    {
        get
        {
            return _isPlayMode;
        }
        set
        {
            _isPlayMode = value;
        }
    }

    // called every frame in play mode
    public virtual void UpdateInPlayMode()
    {

    }

    // called every frame in place mode
    public virtual void UpdateInPlaceMode()
    {

    }

    // called once to construct anything you need for play mode
    public virtual void StartPlayMode()
    {

    }

    // called at the start of a new playthrough (including the first one
    public virtual void ResetPlayMode()
    {

    }

    // called when the game switches back to place mode (not called at the beginning)
    public virtual void StartPlaceMode()
    {

    }

    public virtual void OnSelect()
    {
        if (!isPlayMode)
        {
            Debug.Log("Selected in Place Mode");
            if (mPlacementState == PlacementState.MOVING && mSpawnManager.canPlaceHere && mSpawnManager.toBePlaced == this)
            {
                Debug.Log("Successful Object Placement");
                mPlacementState = PlacementState.PLACED;
                GetComponent<Renderer>().material.color = Color.blue;
                mSpawnManager.ObjectPlaced();
            }
            else if (mPlacementState == PlacementState.PLACED)
            {
                // Enable Context Menu

            }
        }
    }
    
    public void Select()
    {

        //Code for when the thing is selected
        if (mSpawnManager.toBePlaced == null)
        {
            mPlacementState = PlacementState.MOVING;
            mSpawnManager.toBePlaced = this;
        }
    }


}
