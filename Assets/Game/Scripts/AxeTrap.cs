using UnityEngine;
using System.Collections;

public class AxeTrap : ModalObject {

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

}
