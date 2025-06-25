using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public enum Mode
    {
        LookAt,
        LookAtInverted
    }

    [SerializeField] private Mode mode;
    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position- Camera.main.transform.position+transform.position);
                break;
            default:
                Debug.LogWarning("LookAtCamera mode not set correctly.");
                break;
        }
    }
}
