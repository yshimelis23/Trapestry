using UnityEngine;
using System.Collections;

public class ModalObject : MonoBehaviour
{
    private bool _isPlayMode;
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

    // called when the player starts looking at this object
    public virtual void GazeEnter()
    {

    }

    // called when the player stops looking at this object
    public virtual void GazeExit()
    {

    }

    // called when the player clicks on the object
    public virtual void Tap()
    {

    }
}
