using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {

    public static SelectionManager Instance
    {
        get
        {
            return _Instance;
        }
    }
    private static SelectionManager _Instance;

    void Awake()
    {
        _Instance = this;
    }

    public ModalObject selectedObject;

    public void ObjectSelected(ModalObject newObject)
    {
        if (selectedObject != newObject)
        {
            if (selectedObject)
            {
                selectedObject.Deselected();
            }

            selectedObject = newObject;

            selectedObject.Selected();
        }
    }
}
