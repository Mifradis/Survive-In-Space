using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondCounter : MonoBehaviour
{
    public TextMeshProUGUI secs;
    void Update()
    {
        secs.text = ((int)Time.timeSinceLevelLoad).ToString() + " Secs";
    }
}
