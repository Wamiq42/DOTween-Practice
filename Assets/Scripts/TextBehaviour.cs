using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] private Text sampleText;
    [SerializeField] private Vector2[] waypoints;
    [SerializeField] private RectTransform textRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(textRectTransform.DOLocalMove(waypoints[0], 2.0f))
                  .Join(sampleText.DOText("Wamiq Uddin", 2.0f, true, ScrambleMode.All));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
