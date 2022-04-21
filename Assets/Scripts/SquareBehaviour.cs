using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SquareBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float duration;
    [SerializeField] private float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOPath(waypoints,duration,PathType.Linear,PathMode.Full3D,10,null).SetEase(Ease.InOutSine);
        transform.DORotate(Vector3.forward * rotationAngle, duration, RotateMode.FastBeyond360);
    }

   
}
