using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    internal bool isWaitingToStart;

    private float playTimeElapsed;

    [SerializeField]
    private MeshRenderer modeIndicator;
    [SerializeField]
    private MeshRenderer pauseIndicator;

    void Start()
    {
        SwitchToPlaceMode();
    }

    public void KeywordReset()
    {
        GameReset();
    }

    public void KeywordPlay()
    {
        StartPlayMode();
    }

    public void KeywordPause()
    {
        GamePause();
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
        GameResume();
    }

    public void StartPlayMode()
    {
        isWaitingToStart = true;
        isPaused = false;
        pauseIndicator.material.color = Color.yellow;
        playTimeElapsed = 0;

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

        UIManager.Instance.PlayModeUI();
        UIManager.Instance.GreyTimer();

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

        UIManager.Instance.PlaceModeUI();
        UIManager.Instance.DisablePlayButton();

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
                if (!isWaitingToStart && !isPaused)
                {
                    playTimeElapsed += Time.deltaTime;
                }
                UIManager.Instance.UpdateTimer("Time: " + Mathf.Round(100.0f * playTimeElapsed) / 100.0f);
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


    public void PlayerKilled()
    {
        UIManager.Instance.DeathScreen();
    }

    public void PlayerInStartArea()
    {
        if(isWaitingToStart && isPlayMode)
        {
            BeginPlay();
        }
    }
    public void PlayerExitStartArea()
    {

    }

    public void PlayerInEndArea()
    {
        if(!isWaitingToStart && isPlayMode)
        {
            UIManager.Instance.WinScreen();
        }
    }
    public void PlayerExitEndArea()
    {

    }

    //
    public void BeginPlay()
    {
        isWaitingToStart = false;
        UIManager.Instance.WhiteTimer();
        SelectionManager.Instance.DeselectAll();
    }

    public void GamePause()
    {
        if (isPlayMode)
        {
            isPaused = true;
            pauseIndicator.material.color = Color.red;
        }
    }

    public void GameResume()
    {
        isPaused = false;
        pauseIndicator.material.color = Color.green;
    }

    public void GameReset()
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

}
