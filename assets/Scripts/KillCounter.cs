using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KillCounter : MonoBehaviour
{
    public EnemyController destroys;
    public TextMeshProUGUI killCounter;
    void Update()
    {
        killCounter.text = "Kills: " + destroys.getKills().ToString();
    }
}
