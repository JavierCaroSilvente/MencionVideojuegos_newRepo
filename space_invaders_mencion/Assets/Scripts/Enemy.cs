using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private State currentState = State.INIT;
    private bool inGameOver = false;
    private Rigidbody2D rb;
    public enum State
    {
        INIT,
        RIGHT,
        LEFT,
        GAMEOVER
    }

    public State state;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        GameManager.totalEnemies += 1;
        state = State.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case State.INIT:
                
                break;
            case State.RIGHT:
                OnChangeState(State.RIGHT);
                break;
            case State.LEFT:
                OnChangeState(State.LEFT);
                break;
            case State.GAMEOVER:
                OnGameOverState(true);
                break;
        }

        if (transform.position.x <= -6.7f)
        {
            state = State.RIGHT;
        }

        if (transform.position.x >= 6.7f)
        {
            state = State.LEFT;
        }
    }

    private void OnChangeState(State state)
    {
        if(currentState != state)
        {
            currentState = state;
        }
    }

    private void OnGameOverState(bool state)
    {
        if (inGameOver != state)
        {
            EnemyBlock.state = EnemyBlock.State.GAMEOVER;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            inGameOver = state;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Torpedo")
        {
           
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            state = State.GAMEOVER;
        }

        if(other.tag == "ParedIzquierda")
        {
            EnemyBlock.state = EnemyBlock.State.LEFT;
        }

        if (other.tag == "ParedDerecha")
        {
            EnemyBlock.state = EnemyBlock.State.RIGHT;
        }
    }

    private void OnDestroy()
    {
        EnemyBlock.instance.CheckChilds();
        GameManager.totalEnemies -= 1;
    }
}