using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManagerForEnemy : MonoBehaviour
{
    public GameObject gunRightPrefab;
    public GameObject gunLeftPrefab;
    public GameObject fireballPrefab;
    float secondsToNextFireballSpawn = 1.1f;
    float nextFireballSpawn;
    public void Shooting()
    {
        Vector2 spawnPositionLeft;
        Vector2 spawnPositionRight;
        spawnPositionLeft = new Vector2(gunLeftPrefab.transform.position.x, gunLeftPrefab.transform.position.y);
        spawnPositionRight = new Vector2(gunRightPrefab.transform.position.x, gunRightPrefab.transform.position.y);
        if (Time.time > nextFireballSpawn)
        {
            GameObject newFireballLeft = (GameObject)Instantiate(fireballPrefab, spawnPositionLeft, Quaternion.Euler(0, 0, 0));
            GameObject newFireballRight = (GameObject)Instantiate(fireballPrefab, spawnPositionRight, Quaternion.Euler(0, 0, 0));
            nextFireballSpawn = Time.time + secondsToNextFireballSpawn;
        }
    }
    
}
