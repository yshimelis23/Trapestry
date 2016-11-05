using UnityEngine;
using System.Collections;

public class PlayerHeightAdjuster : MonoBehaviour {

    CapsuleCollider mCapsuleCollider;
    float DefaultHeight = 1.5f;

	// Use this for initialization
	void Start () {
        mCapsuleCollider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdatePlayerHeight();
	}

    float DoRayCastToGetHeight()
    {
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out hit))
        {
            return Mathf.Abs(hit.distance);

        }
        else
        {
            return DefaultHeight;
        }
    }

    void UpdatePlayerHeight()
    {
        //Adjust the Height OF the Player's capsule
        float newheight = DoRayCastToGetHeight();
        mCapsuleCollider.height = newheight;
        Vector3 newCenter = mCapsuleCollider.center;
        newCenter.y = -(newheight / 2);
        mCapsuleCollider.center = newCenter;
    }

}
