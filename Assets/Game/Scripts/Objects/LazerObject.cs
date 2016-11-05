using UnityEngine;
using System.Collections;

public class LazerObject : ModalObject {

    float rotation_speed;
    float speedFactor;

    LineRenderer mLineRender;
    [SerializeField]
    GameObject mTip;



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
    }
    public override void StartPlaceMode()
    {

        mLineRender.enabled = false;
    }
    // called every frame in play mode
    public override void UpdateInPlayMode()
    {
      
        mLineRender.SetPosition(0, mTip.transform.position);
        mLineRender.SetPosition(1, mTip.transform.forward * 10);

  
    }


    public void GetRayCastHit()
    {

    }
}
