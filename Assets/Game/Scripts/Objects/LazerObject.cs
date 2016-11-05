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
    Color ActiveLazerColor, PlaceModeLazerColor;

    [SerializeField]
    AudioClip LazerAudioSoundClip;

    Vector3 RayCastEndPoint;



	// Use this for initialization
	void Start () {

        mLineRender = gameObject.GetComponent<LineRenderer>();
        mLineRender.enabled = true;
        mSSoundLazer = (GameObject)Instantiate(SpatialSoundPrefab);
        mSSoundLazer.GetComponent<AudioSource>().clip = LazerAudioSoundClip;
        mSSoundLazer.GetComponent<AudioSource>().loop = true;
        mSSoundLazer.transform.position = mTip.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    // called once to construct anything you need for play mode
    public override void StartPlayMode()
    {
        mLineRender.SetColors(ActiveLazerColor, ActiveLazerColor);
        mSSoundLazer.GetComponent<AudioSource>().enabled = true;
    }
    public override void StartPlaceMode()
    {
        mSSoundLazer.GetComponent<AudioSource>().enabled = false;
        mLineRender.SetColors(PlaceModeLazerColor, PlaceModeLazerColor);
    }
    // called every frame in play mode
    public override void UpdateInPlayMode()
    {
        GetRayCastHitPlayMode();
        if (mLineRender)
        {
            mLineRender.SetPosition(0, mTip.transform.position);
            mLineRender.SetPosition(1, RayCastEndPoint);
        }
     mSSoundLazer.transform.position=(ClosestPointOnLine(mTip.transform.position,RayCastEndPoint,Camera.main.transform.position));
   
  
    }

    public override void UpdateInPlaceMode()
    {
        GetRayCastHitPlaceMode();
        if (mLineRender)
        {
            mLineRender.SetPosition(0, mTip.transform.position);
            mLineRender.SetPosition(1, RayCastEndPoint);
        }

    }
    public void PlayerWasHitByLazer()
    {
        GameManager.Instance.PlayerKilled();
    }

    public void GetRayCastHitPlayMode()
    {
        RaycastHit hit;
        Ray ForwardRay = new Ray(mTip.transform.position, mTip.transform.forward);
        if (Physics.Raycast(ForwardRay, out hit))
        {
            RayCastEndPoint = hit.point;
         if(hit.collider.tag=="MainCamera")
            {
                PlayerWasHitByLazer();
            }

        }
        else
        {
            RayCastEndPoint = mTip.transform.forward * 15;
        }
    }


    public void GetRayCastHitPlaceMode()
    {
        RaycastHit hit;
        Ray ForwardRay = new Ray(mTip.transform.position, mTip.transform.forward);
        if (Physics.Raycast(ForwardRay, out hit))
        {
            RayCastEndPoint = hit.point;
          

        }
        else
        {
            RayCastEndPoint = mTip.transform.forward * 15;
        }
    }


    Vector3 ClosestPointOnLine( Vector3 vA, Vector3 vB,Vector3 vPoint)
    {
        Vector3 vVector1 = vPoint - vA;
        Vector3 vVector2 = (vB - vA).normalized;

        float d = Vector3.Distance(vA, vB);
        float t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return vA;

        if (t >= d)
            return vB;

        Vector3 vVector3 = vVector2 * t;

        Vector3 vClosestPoint = vA + vVector3;

        return vClosestPoint;
    }

}
