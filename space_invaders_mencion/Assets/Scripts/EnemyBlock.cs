using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour
{
    public float speedEnemy;
    private State currentState = State.INIT;
    private bool inGameOver = false;
    public int totalEnemiesBlock;
    public GameObject enemy;

    private float posXEnemies = -1;

    private float limitPosRight = 6.7f;
    private float limitPosLeft = -6.7f;
    public enum State
    {
        INIT,
        RIGHT,
        LEFT,
        GAMEOVER
    }

    public static State state;

    public static EnemyBlock instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        state = State.RIGHT;

        for (int i = 0; i < totalEnemiesBlock; i++)
        {
            posXEnemies += 1.2f;
           // limitPosRight -= 1.1f;

            Vector3 positionEnemy = new Vector3(this.gameObject.transform.position.x + posXEnemies, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

            GameObject newEnemy = Instantiate(enemy, positionEnemy, Quaternion.identity);
            newEnemy.transform.eulerAngles = new Vector3(newEnemy.transform.eulerAngles.x, newEnemy.transform.eulerAngles.y, newEnemy.transform.eulerAngles.z - 180);
            newEnemy.transform.parent = this.gameObject.transform;
        }
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
            case State.GAMEOVER:
                OnGameOverState(true);
                break;
        }

        //if (transform.position.x <= limitPosLeft)
        //{
        //    state = State.RIGHT;
        //}

        //if (transform.position.x >= limitPosRight)
        //{
        //    state = State.LEFT;
        //}
    }

    private void OnChangeState(State state)
    {
        if (currentState != state)
        {
            speedEnemy += 0.3f;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            currentState = state;
        }
    }

    private void OnGameOverState(bool state)
    {
        if (inGameOver != state)
        {
            inGameOver = state;
        }
    }

    internal void CheckChilds()
    {
        if (gameObject.transform.childCount <= 1)
        {
            Destroy(this.gameObject);
        }
    }

}