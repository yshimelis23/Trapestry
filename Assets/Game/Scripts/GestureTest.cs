using UnityEngine;
using System.Collections;

public class GestureTest : MonoBehaviour {

    public void OnGazeEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
    public void OnGazeLeave()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void OnPressed()
    {
        GetComponent<MeshRenderer>().material.color = Color.magenta;
    }
}
