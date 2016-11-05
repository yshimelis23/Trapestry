using UnityEngine;
using System.Collections;

public class Lava : ModalObject {

    AudioSource mAudioSource;
	// Use this for initialization
	void Start () {
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public override void StartPlayMode()
    {
        mAudioSource.enabled = true;
    }

    public override void StartPlaceMode()
    {
        mAudioSource.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        print("MELT MY PRETTY");
        if(isPlayMode)
        {
            if(other.tag=="MainCamera")
            {
                PlayerSteppedOnLava();
            }
        }
    }

    void PlayerSteppedOnLava()
    {
        GameManager.Instance.PlayerKilled();
    }
}
