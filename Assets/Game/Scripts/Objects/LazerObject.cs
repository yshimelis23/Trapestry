using UnityEngine;
using System.Collections;

public class LazerObject : ModalObject {

    float rotation_speed;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    // called once to construct anything you need for play mode
    public override void StartPlayMode()
    {
        rotation_speed = (Camera.main.transform.position - gameObject.transform.position).magnitude;
    }

    // called every frame in play mode
    public override void UpdateInPlayMode()
    {

    }
}
