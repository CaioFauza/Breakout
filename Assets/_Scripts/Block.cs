using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int durability;

    void Start()
    {
        durability = Random.Range(1, 4);;
        HandleBlockColors();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        durability--;
        HandleBlockColors();
        if(durability == 0) Destroy(gameObject);
    }

    private void HandleBlockColors()
    {
        switch (durability)
        {
            case 1:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case 2:
                GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case 3:
                GetComponent<Renderer>().material.color = Color.red;
                break;
        }

    }
}
