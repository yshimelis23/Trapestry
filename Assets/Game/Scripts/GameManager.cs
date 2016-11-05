using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    private static GameManager _Instance;

    void Awake()
    {
        _Instance = this;
    }

    internal bool isPlayMode;
    internal bool isPaused;

    [SerializeField]
    private MeshRenderer modeIndicator;
    [SerializeField]
    private MeshRenderer pauseIndicator;

    [SerializeField]
    private GameObject placeModePanel;
    [SerializeField]
    private GameObject playModeEndPanel;

    [SerializeField]
    private GameObject placeModeInstructionPanel;

    void Start()
    {
        SwitchToPlaceMode();
    }

    public void KeywordReset()
    {
        if (isPlayMode)
        {
            StartPlayMode();
        }
        else
        {
            SwitchToPlaceMode();
        }
    }

    public void KeywordPlay()
    {
        StartPlayMode();
    }

    public void KeywordPause()
    {
        if (isPlayMode)
        {
            isPaused = true;
            pauseIndicator.material.color = Color.red;
        }
    }

    public void KeywordClear()
    {
        if (!isPlayMode)
        {
            ClearObjects();
        }
    }


    public void KeywordResume()
    {
        isPaused = false;
        pauseIndicator.material.color = Color.green;
    }

    public void StartPlayMode()
    {
        isPaused = false;
        pauseIndicator.material.color = Color.green;

        if (!isPlayMode)
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

        placeModeInstructionPanel.SetActive(false);
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(false);

        isPlayMode = true;
        modeIndicator.material.color = Color.blue;
    }

    public void SwitchToPlaceMode()
    {
        isPaused = false;
        pauseIndicator.material.color = Color.green;

        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            obj.StartPlaceMode();
            obj.isPlayMode = false;
        }

        StartCoroutine(PlaceModeInstructionRoutine());
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(true);

        isPlayMode = false;
        modeIndicator.material.color = Color.magenta;
    }

    public void ClearObjects()
    {
        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            Destroy(obj.gameObject);
        }
    }

    public void Update()
    {
        if (!isPaused)
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

    private IEnumerator PlaceModeInstructionRoutine()
    {
        placeModeInstructionPanel.SetActive(true);

        yield return new WaitForSeconds(15);

        placeModeInstructionPanel.SetActive(false);
    }

    public void PlayerKilled()
    {
        playModeEndPanel.SetActive(true);
    }
}
