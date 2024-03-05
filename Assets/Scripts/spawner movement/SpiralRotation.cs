using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralRotation : MonoBehaviour
{
    public float speed;
    public bool counter_clockwise;
    private bool isRotating = false;

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        StartCoroutine("rotate");
    }

    IEnumerator rotate()
    {
        isRotating = true;
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            if (counter_clockwise)
                transform.Rotate(Vector3.down * speed * Time.deltaTime);
            else
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
            yield return null;
        }
        isRotating = false;
    }
}
