using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] private Text sampleText;
    [SerializeField] private Vector3[] waypoints;
    [SerializeField] private float duration;
    [SerializeField] private float rotationAngle;
    [SerializeField] private RectTransform textRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(textRectTransform.DOLocalMove(waypoints[0], 2.0f))
                  .Join(sampleText.DOText("Wamiq Uddin", duration, true, ScrambleMode.All))
                  .Join(sampleText.DOBlendableColor(Color.green , 2))
                  .Join(textRectTransform.DOLocalRotate(Vector3.forward * rotationAngle, duration));
        
    }

}
