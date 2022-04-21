using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SquareBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2[] waypoints;
    [SerializeField] private Rigidbody2D squareRigidbody;
    [SerializeField] private float duration;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        squareRigidbody.DOPath(waypoints,duration,PathType.Linear,PathMode.Full3D,10,null).SetEase(Ease.InOutSine);
        squareRigidbody.DORotate(360*2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
