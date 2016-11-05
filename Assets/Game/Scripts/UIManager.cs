using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    private static UIManager _Instance;

    void Awake()
    {
        _Instance = this;
    }

    [SerializeField]
    private GameObject placeModePanel;
    [SerializeField]
    private GameObject playModeEndPanel;

    [SerializeField]
    private GameObject timerPanel; // contains label for timer
    [SerializeField]
    private Text timerLabel; // text on timer panel

    [SerializeField]
    private GameObject placeModeInstructionPanel;

    public void PlayModeUI()
    {
        placeModeInstructionPanel.SetActive(false);
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(false);
        timerPanel.SetActive(true);
    }

    public void PlaceModeUI()
    {
        StartCoroutine(PlaceModeInstructionRoutine());
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(true);
        timerPanel.SetActive(false);
    }

    public void EnablePlacementMenu()
    {
        placeModePanel.SetActive(false);
    }

    public void DisablePlacementMenu()
    {
        placeModePanel.SetActive(true);
    }

    public void UpdateTimer(string text)
    {
        timerLabel.text = text;
    }


    private IEnumerator PlaceModeInstructionRoutine()
    {
        placeModeInstructionPanel.SetActive(true);

        yield return new WaitForSeconds(15);

        placeModeInstructionPanel.SetActive(false);
    }

    public void DeathScreen()
    {
        playModeEndPanel.SetActive(true);
    }

    public void WinScreen()
    {
        playModeEndPanel.SetActive(true);
    }
}
