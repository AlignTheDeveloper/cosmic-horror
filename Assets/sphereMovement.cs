using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private Transform sphereCenter; //transform of play space
    [SerializeField] private float radius = 5f; //radius from the center of the play space to set the ship at 
    [SerializeField] private float speed = 5f; 
    private Vector3 spherePos;

    private float dirX;
    private float dirY;


    void Start()
    {
        // Set the ship at 0, 0, radius
        transform.position = sphereCenter.position + new Vector3(0, -radius, 0);
    }
    void Update()
    {
        dirX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        dirY += Input.GetAxis("Vertical") * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        ShipMovement(dirX, dirY);
    }

    void ShipMovement(float theta, float phi)
    // calculations taken from https://en.neurochispas.com/trigonometry/spherical-to-cartesian-coordinates-formulas-and-examples/

    {
        // Calculate the new position of the ship
        spherePos.x = sphereCenter.position.x + radius * Mathf.Sin(phi) * Mathf.Cos(theta);
        spherePos.y = sphereCenter.position.z + radius * Mathf.Cos(phi);
        spherePos.z = sphereCenter.position.y + radius * Mathf.Sin(phi) * Mathf.Sin(theta);

        // Set the position of the ship
        transform.position = spherePos;
        transform.LookAt(sphereCenter);
    }
}
