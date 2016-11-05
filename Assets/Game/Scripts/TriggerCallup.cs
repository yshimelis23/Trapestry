using UnityEngine;
using System.Collections;

public class TriggerCallup : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<ContainsTracker>().OnTriggerEnter(other);
    }
    public void OnTriggerExit(Collider other)
    {
        GetComponentInParent<ContainsTracker>().OnTriggerExit(other);
    }
}
