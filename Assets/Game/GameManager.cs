using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    private GameManager _Instance;

    void Awake()
    {
        _Instance = this;
    }

    internal bool isPlayMode;


    public void KeywordReset()
    {

    }

    public void KeywordPlay()
    {

    }

    public void KeywordPause()
    {

    }

    public void KeywordResume()
    {

    }

    public void StartPlayMode()
    {
        if (isPlayMode)
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.StartPlayMode();
                obj.isPlayMode = true;
            }
        }

        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            obj.ResetPlayMode();
        }

    }

    public void SwitchToPlaceMode()
    {
        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            Destroy(obj.gameObject);
        }
    }

    public void Update()
    {
        if (isPlayMode)
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.UpdateInPlayMode();
            }
        }
        else
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.UpdateInPlaceMode();
            }
        }
    }
}
