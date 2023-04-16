using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject gunRightPrefab;
    public GameObject gunLeftPrefab;
    public GameObject fireballPrefab;
    float secondsToNextFireballSpawn;
    public void Shooting()
    {
        Vector2 spawnPositionLeft = new Vector2(gunLeftPrefab.transform.position.x, gunLeftPrefab.transform.position.y);
        Vector2 spawnPositionRight = new Vector2(gunRightPrefab.transform.position.x, gunRightPrefab.transform.position.y);
        GameObject newFireballLeft = (GameObject)Instantiate(fireballPrefab, spawnPositionLeft, Quaternion.Euler(0, 0, 180));
        GameObject newFireballRight = (GameObject)Instantiate(fireballPrefab, spawnPositionRight, Quaternion.Euler(0, 0, 180));
    }
    
}
