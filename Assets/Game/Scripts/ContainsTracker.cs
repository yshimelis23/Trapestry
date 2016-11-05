using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ContainsTracker : FloorObject
{
    public event Action playerEnterCallback;
    public event Action playerExitCallback;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && playerEnterCallback != null)
        {
            playerEnterCallback.Invoke();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera" && playerExitCallback != null)
        {
            playerExitCallback.Invoke();
        }
    }

    public void SetAsStart()
    {
        playerEnterCallback += GameManager.Instance.PlayerInStartArea;
        playerExitCallback += GameManager.Instance.PlayerExitStartArea;
    }
    public void SetAsGoal()
    {
        playerEnterCallback += GameManager.Instance.PlayerInEndArea;
        playerExitCallback += GameManager.Instance.PlayerExitEndArea;
    }

}
