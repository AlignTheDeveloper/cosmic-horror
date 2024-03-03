using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotation : MonoBehaviour
{
    private float timeBetweenRotations;
    private Quaternion firstRotation;
    private Quaternion secondRotation;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            randomizeRotation();
        }
    }

    void randomizeRotation()
    {
        firstRotation = transform.rotation;
        secondRotation = Random.rotation;
        StartCoroutine("rotate");
    }

    IEnumerator rotate()
    {
        isRotating = true;
        timeBetweenRotations = Random.Range(1, 5);
        float elapsedTime = 0;
        while (elapsedTime < timeBetweenRotations)
        {
            transform.rotation = Quaternion.Slerp(firstRotation, secondRotation, elapsedTime / timeBetweenRotations);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isRotating = false;
    }
}
