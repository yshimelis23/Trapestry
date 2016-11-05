using UnityEngine;
using System.Collections;

public class Needles : ModalObject {

    public Animator mAnimtions;
    float Timer=0;

	// Use this for initialization
	void Start () {
        mAnimtions.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void UpdateInPlayMode()
    {

    }

}
