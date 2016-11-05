using UnityEngine;
using System.Collections;

public class GestureChild : MonoBehaviour {
    public void OnGazeEnter()
    {
        transform.parent.SendMessage("OnGazeEnter");
    }
    public void OnGazeLeave()
    {
        transform.parent.SendMessage("OnGazeLeave");
    }
    public void OnPressed()
    {
        transform.parent.SendMessage("OnPressed");
    }
    public void OnReleased()
    {
        transform.parent.SendMessage("OnReleased");
    }
    public void OnSelect()
    {
        transform.parent.SendMessage("OnSelect");
    }
}
