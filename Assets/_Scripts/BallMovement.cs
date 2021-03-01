using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    GameManager gm;
    [Range(1, 15)]
    public float speed = 5.0f;
    private Vector3 course;

    public AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        float courseX = Random.Range(-5.0f, 5.0f);
        float courseY = Random.Range(1.0f, 5.0f);
        course = new Vector3(courseX, courseY).normalized; 
        
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if(gm.gameState == GameManager.GameState.START)
        { 
            Reset();   
            gm.ChangeState(GameManager.GameState.GAME);
        }
        if(gm.gameState != GameManager.GameState.GAME) return;

        transform.position += course * Time.deltaTime * speed;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if(viewportPosition.x < 0 || viewportPosition.x > 1){ course = new Vector3(-course.x, course.y); }
        if(viewportPosition.y < 0 || viewportPosition.y > 1){ course = new Vector3(course.x, -course.y); }
        if(viewportPosition.y < 0){ Reset(); }
    }

    private void Reset()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);
        
        float courseX = Random.Range(-5.0f, 5.0f);
        float courseY = Random.Range(2.0f, 5.0f);
        course = new Vector3(courseX, courseY).normalized;

        gm.lifes--;
        if(gm.lifes <= 0 && gm.gameState == GameManager.GameState.GAME){ gm.ChangeState(GameManager.GameState.END); }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            float courseX = Random.Range(-5.0f, 5.0f);
            float courseY = Random.Range(1.0f, 5.0f);
            course = new Vector3(courseX, courseY).normalized;
        }
        else if(collision.gameObject.CompareTag("Brick"))
        {   
            course = new Vector3(course.x, -course.y);
            gm.points++;
            if(gm.points == 10) gm.powerUps = 1;
            audioSource.PlayOneShot(hitSound);
        }
    }
}
