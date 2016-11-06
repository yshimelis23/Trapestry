using UnityEngine;
using System.Collections;

public class FloorObject : ModalObject {

    // called every frame in play mode
    public override void UpdateInPlayMode()
    {
        base.UpdateInPlayMode();

    }

    // called every frame in place mode
    public override void UpdateInPlaceMode()
    {
        base.UpdateInPlaceMode();

    }

    // called once to construct anything you need for play mode
    public override void StartPlayMode()
    {
        base.StartPlayMode();

    }

    // called at the start of a new playthrough (including the first one
    public override void ResetPlayMode()
    {
        base.ResetPlayMode();
    }

    public override void PlaceOnSurface(Vector3 position, Vector3 normal)
    {
        transform.position = position;
        transform.rotation = Quaternion.identity;
    }

    public override bool IsValidSurface(PlacementSurface surface)
    {
        return surface == PlacementSurface.Ceiling || surface == PlacementSurface.Wall;
    }

}
