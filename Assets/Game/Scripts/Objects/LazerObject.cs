using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LazerObject : ModalObject {

    public GameObject SpatialSoundPrefab;
    private GameObject mSSoundLazer;

    LineRenderer mLineRender;
    [SerializeField]
    GameObject mTip;

    [SerializeField]
    AudioClip LazerAudioSoundClip;

    Vector3 RayCastEndPoint;



	// Use this for initialization
	void Start () {

        mLineRender = gameObject.GetComponent<LineRenderer>();
        mLineRender.enabled = false;
        mSSoundLazer = (GameObject)Instantiate(SpatialSoundPrefab);
        mSSoundLazer.GetComponent<AudioSource>().clip = LazerAudioSoundClip;
        //ADD AUIDO TO POINT ON LINE
        
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


    Vector3 GetClosetPoint(Vector3 Dir, Vector3 P, bool segmentClamp)
    {
        Vector3 AP = P -gameObject.transform.position;
    Vector3 AB = Dir;
        float ab2 = AB.x * AB.x + AB.y * AB.y;
        float ap_ab = AP.x * AB.x + AP.y * AB.y;
        float t = ap_ab / ab2;
        if (segmentClamp)
        {
            if (t < 0.0f) t = 0.0f;
            else if (t > 1.0f) t = 1.0f;
        }
        Vector3 Closest = gameObject.transform.position + AB * t;
        return Closest;
    }

}
