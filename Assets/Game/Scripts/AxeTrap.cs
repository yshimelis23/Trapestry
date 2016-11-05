using UnityEngine;
using System.Collections;

public class AxeTrap : WallObject {

    public Animation mAnimation;

	// Use this for initialization
	void Start () {
    
        mAnimation.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void StartPlayMode()
    {

        mAnimation.Play();
    }

    public override void UpdateInPlayMode()
    {

        
    }

    public override void StartPlaceMode()
    {

        mAnimation.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
      
        if (isPlayMode)
        {
            if (other.tag == "MainCamera")
            {
                PlayerSlashed();
            }
        }
    }

    void PlayerSlashed()
    {
        GameManager.Instance.PlayerKilled();
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
