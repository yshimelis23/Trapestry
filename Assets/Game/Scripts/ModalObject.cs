using UnityEngine;
using System.Collections;

public class ModalObject : MonoBehaviour
{
    public enum PlacementState
    {
        PLACED,
        MOVING
    }
    private PlacementState mPlacementState = PlacementState.MOVING;

    public void SetState(PlacementState newState)
    {
        switch (newState)
        {
            case PlacementState.PLACED:
                // enable collider
                // change color
                GetComponent<Renderer>().material.color = new Color(0,0,1,0.5f);
                break;
            case PlacementState.MOVING:
                // disable collider
                // change color
                GetComponent<Renderer>().material.color = new Color(1,1,1,1);
                break;
        }
    }

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
            SelectionManager.Instance.ObjectSelected(this);
        }
    }

    public PropertyMenu propertyMenu;
    private PropertyMenu currentMenu;

    // called when this object is selected
    public virtual void Selected()
    {
        currentMenu = Instantiate(propertyMenu);
        currentMenu.destroyObject += () => { Destroy(this.gameObject); };
        currentMenu.moveObject += () => {
            SetState(PlacementState.MOVING);
            SpawnManager.Instance.objectToPlace = this;
        };


    }

    // called when this object is deselected
    public virtual void Deselected()
    {
        if (currentMenu)
        {
            Destroy(currentMenu.gameObject);
        }
    }
}
