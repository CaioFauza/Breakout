using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject Block;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Build;
        Build();
    }

    void Update()
    {
        if(transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.END);
        }
    }

    void Build()
    {
        if(gm.gameState == GameManager.GameState.START)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 2; i < 11; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Vector3 position = new Vector3(-9.3f + 1.55f * i, 4 - 0.55f * j);
                    Instantiate(Block, position, Quaternion.identity, transform);
                }
            }
        }
    }
}
