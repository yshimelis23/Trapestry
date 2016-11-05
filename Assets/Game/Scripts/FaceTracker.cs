using UnityEngine;
using System.Collections;

public class FaceTracker : MonoBehaviour
{
    public float distanceFromFace = 3f;
    public float lerpSpeed = 0.3f;

    private Vector3 targetPos;

	void Update () {
        // find look direction
        Vector3 look = Camera.main.transform.rotation * Vector3.forward;
        Vector3 pos = Camera.main.transform.position;

        // find optimal placement in front a certain distance away
        Vector3 optimalPosition = pos + distanceFromFace * look;

        if(Vector3.Distance(optimalPosition, targetPos) > 1) {
            targetPos = optimalPosition;
        }

        // lerp there
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime / lerpSpeed);
        transform.rotation = Quaternion.LookRotation(transform.position - pos, Vector3.up);
    }
}
