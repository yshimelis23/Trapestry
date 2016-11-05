using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GestureEnabledButton : MonoBehaviour {
    public void OnGazeEnter()
    {
        GetComponent<Button>().Select();
    }
    public void OnGazeLeave()
    {
        if(EventSystem.current.currentSelectedGameObject == this.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    public void OnPressed()
    {
        GetComponent<Button>().onClick.Invoke();
    }
}
