using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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
    private Button playButton;

    [SerializeField]
    private GameObject placeModePanel;
    [SerializeField]
    private GameObject playModeEndPanel;

    [SerializeField]
    private GameObject startInstructionPanel;
    [SerializeField]
    private GameObject pauseInstructionPanel;

    [SerializeField]
    private GameObject startExplanationPanel;
    [SerializeField]
    private GameObject endExplanationPanel;
    [SerializeField]
    private GameObject laserExplanationPanel;
    [SerializeField]
    private GameObject trapExplanationPanel;
    [SerializeField]
    private GameObject lavaExplanationPanel;

    [SerializeField]
    private GameObject deathExplanationPanel;
    [SerializeField]
    private GameObject winExplanationPanel;

    [SerializeField]
    private GameObject timerPanel; // contains label for timer
    [SerializeField]
    private Text timerLabel; // text on timer panel

    [SerializeField]
    private GameObject placeModeInstructionPanel;

    [SerializeField]
    private FaceTracker canvasFaceTracker;
    [SerializeField]
    private Text lockButtonText;

    public void ToggleLockMenu()
    {
        if (canvasFaceTracker.freeMove)
        {
            canvasFaceTracker.freeMove = false;
            lockButtonText.text = "Unlock";
        }
        else
        {
            canvasFaceTracker.freeMove = true;
            lockButtonText.text = "Lock";
        }
    }

    public void PlayModeUI()
    {
        placeModeInstructionPanel.SetActive(false);
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(false);
        timerPanel.SetActive(true);
        deathExplanationPanel.SetActive(false);
        winExplanationPanel.SetActive(false);
    }

    public void PlaceModeUI()
    {
        StartCoroutine(PlaceModeInstructionRoutine());
        playModeEndPanel.SetActive(false);
        placeModePanel.SetActive(true);
        timerPanel.SetActive(false);
        deathExplanationPanel.SetActive(false);
        winExplanationPanel.SetActive(false);
    }

    public void EnablePlacementMenu()
    {
        placeModePanel.SetActive(true);
    }

    public void DisablePlacementMenu()
    {
        placeModePanel.SetActive(false);
    }

    public void UpdateTimer(string text)
    {
        timerLabel.text = text;
    }

    public void GreyTimer()
    {
        timerLabel.color = Color.grey;
    }

    public void WhiteTimer()
    {
        timerLabel.color = Color.white;
    }


    public void DisablePlayButton()
    {
        playButton.interactable = false;
    }

    public void EnablePlayButton()
    {
        playButton.interactable = true;
    }

    internal void LaserInstruction()
    {
        laserExplanationPanel.SetActive(true);
    }

    internal void LavaInstruction()
    {
        lavaExplanationPanel.SetActive(true);
    }

    internal void TrapInstruction()
    {
        trapExplanationPanel.SetActive(true);
    }

    internal void StartInstruction()
    {
        startExplanationPanel.SetActive(true);
    }

    internal void GoalInstruction()
    {
        endExplanationPanel.SetActive(true);
    }

    internal void HideInstructions()
    {
        startExplanationPanel.SetActive(false);
        endExplanationPanel.SetActive(false);
        laserExplanationPanel.SetActive(false);
        lavaExplanationPanel.SetActive(false);
        trapExplanationPanel.SetActive(false);
    }

    private IEnumerator PlaceModeInstructionRoutine()
    {
        placeModeInstructionPanel.SetActive(true);

        yield return new WaitForSeconds(15);

        //placeModeInstructionPanel.SetActive(false);
    }

    public void DeathScreen()
    {
        playModeEndPanel.SetActive(true);
        deathExplanationPanel.SetActive(true);
    }

    public void WinScreen()
    {
        playModeEndPanel.SetActive(true);
        winExplanationPanel.SetActive(true);
    }

    public void ShowPauseScreen()
    {
        pauseInstructionPanel.SetActive(true);
    }

    public void HidePauseScreen()
    {
        pauseInstructionPanel.SetActive(false);
    }

    public void ShowStartScreen()
    {
        startInstructionPanel.SetActive(true);
    }

    public void HideStartScreen()
    {
        startInstructionPanel.SetActive(false);
    }
}
