using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestureEnabledButton : MonoBehaviour {
    public void OnGazeEnter()
    {
        GetComponent<Button>().Select();
    }
    public void OnPressed()
    {
        GetComponent<Button>().onClick.Invoke();
    }
}
