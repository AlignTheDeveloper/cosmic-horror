using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletLife;
    public float bulletSpeed;

    public float spawnInterval;

    private GameObject spawnedBullet;
    private float spawnTimer;

    void Start()
    {
        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            fireBullet();
            spawnTimer = 0f;
        }
    }

    private void fireBullet()
    {
        if(bulletPrefab != null)
        {
            spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<bullet>().lifetime = bulletLife;
            spawnedBullet.GetComponent<bullet>().speed = bulletSpeed;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
