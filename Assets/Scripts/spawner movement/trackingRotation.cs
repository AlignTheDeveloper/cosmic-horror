using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackingRotation : MonoBehaviour
{
    public float speed;
    private Quaternion firstRotation;
    private Quaternion secondRotation;
    private bool isRotating = false;
    private Transform target;
    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (!isRotating)
        {
            TrackingRotate();
        }
    }

    void TrackingRotate()
    {
        firstRotation = transform.rotation;
        secondRotation = Quaternion.LookRotation(target.position - transform.position);
        StartCoroutine("rotate");
    }

    IEnumerator rotate()
    {
        isRotating = true;
        float elapsedTime = 0;
        while (elapsedTime < speed)
        {
            transform.rotation = Quaternion.Slerp(firstRotation, secondRotation, elapsedTime / speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isRotating = false;
        TrackingRotate();
    }
}
