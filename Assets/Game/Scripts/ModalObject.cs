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

    // called when the game switches back to place mode (not called at the beginning)
    public virtual void StartPlaceMode()
    {

    }

}
