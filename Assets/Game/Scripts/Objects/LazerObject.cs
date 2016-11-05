using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LazerObject : ModalObject {

    float rotation_speed;
    float speedFactor;

    LineRenderer mLineRender;
    [SerializeField]
    GameObject mTip;

    Vector3 RayCastEndPoint;



	// Use this for initialization
	void Start () {
        speedFactor = 2;
        mLineRender = gameObject.GetComponent<LineRenderer>();
        mLineRender.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    // called once to construct anything you need for play mode
    public override void StartPlayMode()
    {
        mLineRender.enabled = true;
        print("IM TURNING UP SO U BETTER GET THIS PARTY STARTED");
    }
    public override void StartPlaceMode()
    {

        mLineRender.enabled = false;
    }
    // called every frame in play mode
    public override void UpdateInPlayMode()
    {
        GetRayCastHit();
        mLineRender.SetPosition(0, mTip.transform.position);
        mLineRender.SetPosition(1, RayCastEndPoint);

  
    }


    public void GetRayCastHit()
    {
        RaycastHit hit;
        Ray ForwardRay = new Ray(mTip.transform.position, mTip.transform.forward);
        if (Physics.Raycast(ForwardRay, out hit))
        {
            RayCastEndPoint = hit.point;
         if(hit.collider.tag=="MainCamera")
            {
                GameManager.Instance.PlayerKilled();
            }

        }
        else
        {
            RayCastEndPoint = mTip.transform.forward * 15;
        }
    }
}
