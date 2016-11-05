using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool isPlayMode;

	public void StartPlayMode()
    {
        if (isPlayMode)
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.StartPlayMode();
                obj.isPlayMode = true;
            }
        }

        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            obj.ResetPlayMode();
        }

    }

    public void SwitchToPlaceMode()
    {
        foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
        {
            Destroy(obj.gameObject);
        }
    }

    public void Update()
    {
        if (isPlayMode)
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.UpdateInPlayMode();
            }
        }
        else
        {
            foreach (ModalObject obj in GameObject.FindObjectsOfType<ModalObject>())
            {
                obj.UpdateInPlaceMode();
            }
        }
    }
}
