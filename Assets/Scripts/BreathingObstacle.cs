using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingObstacle : MonoBehaviour
{
    [SerializeField] float minScale = 0.5f;
    [SerializeField] float maxScale = 1f;
    [SerializeField] float scaleSpeed = 1;
    [SerializeField] float startingScale = 1;
    float currentScale;
    [SerializeField] bool isExpanding;
    // Start is called before the first frame update
    void Start()
    {
        currentScale = startingScale;
    }

    // Update is called once per frame
    void Update()
    {
        RescalingLoop();
        gameObject.transform.localScale = Vector3.one * currentScale;
    }
    void RescalingLoop()
    {
        if(isExpanding)
        {
            if(currentScale < maxScale)
            {
                currentScale += Time.deltaTime * scaleSpeed;
                return;
            }
            currentScale = maxScale;
            isExpanding = false;
        }
        else
        {
            if (currentScale > minScale)
            {
                currentScale -= Time.deltaTime * scaleSpeed;
                return;
            }
            currentScale = minScale;
            isExpanding = true;
        }
    }
}
