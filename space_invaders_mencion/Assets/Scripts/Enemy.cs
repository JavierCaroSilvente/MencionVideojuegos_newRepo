using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy;
    private State currentState = State.INIT;
    public enum State
    {
        INIT,
        RIGHT,
        LEFT
    }

    public State state;

    void Start()
    {
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
                transform.Translate(Vector3.right * Time.deltaTime * speedEnemy);
                OnChangeState(State.RIGHT);
                break;
            case State.LEFT:
                transform.Translate(Vector3.left * Time.deltaTime * speedEnemy);
                OnChangeState(State.LEFT);
                break;
        }

        if (transform.position.x <= -6.7f)
        {
            state = State.LEFT;
        }

        if (transform.position.x >= 6.7f)
        {
            state = State.RIGHT;
        }
    }

    private void OnChangeState(State state)
    {
        if(currentState != state)
        {
            speedEnemy += 0.5f;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            currentState = state;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Torpedo")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}