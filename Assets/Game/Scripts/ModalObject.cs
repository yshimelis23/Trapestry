using UnityEngine;
using System.Collections.Generic;
using System;

public class ModalObject : MonoBehaviour
{
    [SerializeField]
    static AudioClip placementSound;
    public Collider myCollider;


    public Renderer[] myRenderers;
    private List<Color> myColors;

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
                myCollider.enabled = true;
                // change color
                SetColor(new Color(0, 0, 1, 0.5f));
                // play placement sound
                AudioSource mAudio = GetComponent<AudioSource>();
                if (mAudio != null)
                {
                    mAudio.PlayOneShot(GameManager.Instance.placementSound);
                }
                break;
            case PlacementState.MOVING:
                // disable collider
                myCollider.enabled = false;
                // change color
                ResetColor();
                break;
        }
        mPlacementState = newState;
    }

    public void SetColor(Color c)
    {
        foreach (Renderer r in myRenderers)
        {
            if (r != null && r.material != null)
            {
                r.material.color = c;
            }
        }
    }

    public void ResetColor()
    {
        int i = 0;
        foreach (Renderer r in myRenderers)
        {
            if (r != null && r.material != null)
            {
                r.material.color = myColors[i];
            }
            i++;
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

    // called when spawned
    public virtual void Initialize()
    {
        myColors = new List<Color>();
        foreach (Renderer r in myRenderers)
        {
            if (r != null && r.material != null)
            {
                myColors.Add(r.material.color);
            }
            else
            {
                myColors.Add(Color.white);
            }
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

    // use the information in the node object to set up your look direction or floor area
    public virtual void SetSecondNode(GameObject node)
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
        currentMenu.transform.position = this.transform.position;
        currentMenu.destroyObject += () => {
            Destroy(this.gameObject);
            SelectionManager.Instance.DeselectAll();
        };
        currentMenu.moveObject += () =>
        {
            SpawnManager.Instance.StartPlacingObject(this);
        };
        currentMenu.placeNewLookPoint += () =>
        {
            SpawnManager.Instance.StartNode(this);
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

    public virtual bool IsValidSurface(PlacementSurface surface)
    {
        return surface != PlacementSurface.Invalid;
    }

    public virtual void PlaceOnSurface(Vector3 position, Vector3 normal)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(normal);
    }
}
