using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    GameManager gm;
    [Range(1, 10)]
    public float speed = 5.0f;
    private GameObject brick;

    public AudioSource audioSource;
    public AudioClip powerUpSound;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {   
        if(gm.gameState == GameManager.GameState.START)
        { 
            gm.ChangeState(GameManager.GameState.GAME);
        }

        if(gm.gameState != GameManager.GameState.GAME) return;
        float inputX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * speed;
        
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        if(Input.GetKeyDown(KeyCode.P) && gm.powerUps == 1)
        {
           gm.powerUps = 0;
           ActivePowerUp();
        }
    }

    void ActivePowerUp()
    {   
        audioSource.PlayOneShot(powerUpSound, 5.0f);
        gm.powerUpUsed = true;
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        for(int i = 0; i < 15; i++)
        {
            GameObject.Destroy(bricks[i]);
            gm.points++;
        }
      
    }
}
