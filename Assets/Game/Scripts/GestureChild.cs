using UnityEngine;
using System.Collections;

public class GestureChild : MonoBehaviour {
    public void OnGazeEnter()
    {
        transform.parent.SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
    }
    public void OnGazeLeave()
    {
        transform.parent.SendMessage("OnGazeLeave", SendMessageOptions.DontRequireReceiver);
    }
    public void OnPressed()
    {
        transform.parent.SendMessage("OnPressed", SendMessageOptions.DontRequireReceiver);
    }
    public void OnReleased()
    {
        transform.parent.SendMessage("OnReleased", SendMessageOptions.DontRequireReceiver);
    }
    public void OnSelect()
    {
        transform.parent.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
    }
}
