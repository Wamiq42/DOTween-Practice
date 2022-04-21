using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallBehaviour : MonoBehaviour
{

    //private float horizontalInput;
    private Material ballMaterial;
    private float moveDistance = 0;
   
    public float bounceDistance = 0;
    public float bounceDuration = 0;
    public float forwardMoveDuration = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballMaterial = GetComponent<SpriteRenderer>().material;
        BallBounce();
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
        transform.DOMoveY(bounceDistance, bounceDuration).OnComplete(ChangeColorAtHighestPoint);

    }





    private void BallBounce()
    {


        var sequence = DOTween.Sequence()
            .Append(transform.DOMoveY(bounceDistance, bounceDuration).SetEase(Ease.InOutSine))
            .Join(transform.DOScale(new Vector3(0.5f, 0.5f), bounceDuration).SetEase(Ease.InOutSine))
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
