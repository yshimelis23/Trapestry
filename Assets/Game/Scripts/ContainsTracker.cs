using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ContainsTracker : MonoBehaviour
{
    public event Action playerEnterCallback;
    public event Action playerExitCallback;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && playerEnterCallback != null)
        {
            playerEnterCallback.Invoke();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera" && playerExitCallback != null)
        {
            playerExitCallback.Invoke();
        }
    }

}
