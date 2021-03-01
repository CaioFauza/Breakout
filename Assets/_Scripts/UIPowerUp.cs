using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerUp : MonoBehaviour
{
    Text textComp;
    GameManager gm;

    void Start()
    {
        textComp = GameObject.Find("UI_PowerUp").GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {   
        string message = gm.points < 10 ? $"Hit {10 - gm.points} more blocks to unlock it" : "UNLOCKED | Activate with key P";
        textComp.text = gm.powerUpUsed ? "" : $"PowerUp: {message}";
    }
}
