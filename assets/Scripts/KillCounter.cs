using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KillCounter : MonoBehaviour
{
    public int destroys = 0;
    public TextMeshProUGUI killCounter;
    public TextMeshProUGUI endGameDestroys;
    public string destroyText;
    void Update()
    {
        killCounter.text = "Kills: " + getDestroys().ToString();
        destroyText = "You Destroyed: " + getDestroys().ToString() + " Ships";
        endGameDestroys.text = destroyText;
    }
    public int getDestroys()
    {
        return destroys;
    }
    public void setDestroys(int num)
    {
        this.destroys = num;
    }
    public string getDestroyText()
    {
        return this.destroyText;
    }
}
