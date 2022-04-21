using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallBehaviour : MonoBehaviour
{


    //private float horizontalInput;
    private Material ballMaterial;
    private float moveDistance = 0;
   
    [SerializeField] private float bounceDistance = 0;
    [SerializeField] private float bounceDuration = 0;
    [SerializeField] private float forwardMoveDuration = 0;
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private Vector3 scale = new Vector3(0.5f,0.5f);

    // Start is called before the first frame update
    void Start()
    {
        ballMaterial = GetComponent<SpriteRenderer>().material;
        BallBounce();
        //BallBounceAlternate();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        //BallBounceAlternate();
    }



    private void MoveBall()
    {
        Debug.Log("before Animation" + transform.position);
        //horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveDistance += 1;
            //Debug.Log("If statement Accessed");
            transform.DOMoveX(moveDistance, forwardMoveDuration);

            Debug.Log("After Animation" + transform.position);

        }
        else
        {
            DOTween.Pause(gameObject);
        }
    }

    private void BallBounceAlternate()
    {
        Sequence circleSequence = DOTween.Sequence();
        circleSequence.Append(transform.DOPath(waypoints, bounceDuration, PathType.Linear, PathMode.Full3D).SetEase(Ease.InOutSine));
        circleSequence.Join(transform.DOScale(scale, bounceDuration).SetEase(Ease.InOutFlash));
        circleSequence.SetLoops(-1, LoopType.Yoyo);
            
        
    }





    private void BallBounce()
    {


        var sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(bounceDistance, bounceDuration).SetEase(Ease.InOutSine))
            .Join(transform.DOScale(scale, bounceDuration).SetEase(Ease.InOutSine))
            .Join(ballMaterial.DOBlendableColor(Color.red, bounceDuration).SetEase(Ease.InOutFlash));

        sequence.SetLoops(-1, LoopType.Yoyo);



    }

    

    private void ChangeColorAtHighestPoint()
    {
        ballMaterial.color = Color.blue;
    }
    private void ChangeColorAtLowestPoint()
    {
        ballMaterial.color = Color.red;
    }

    
}
