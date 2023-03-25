using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1);
    private Vector3 startSpeed;

    public string keyToCheck = "Player";

    [Header("Randomization")]
    public Vector2 randSPeedY = new Vector2(1, 3);
    public Vector2 randSPeedX = new Vector2(1, 3);

    private Vector3 _starPosition;
    private bool _canMove = false;

    private void Awake()
    {
        _starPosition = transform.position;
        startSpeed = speed;
    }


    private void Update()
    {
        if (!_canMove) return;

        transform.Translate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == keyToCheck)
            OnPlayerCollision();
        else
            speed.y = speed.y * -1;
    }

    private void OnPlayerCollision()
    {
        speed.x = speed.x * -1;

        float rand = Random.Range(randSPeedX.x, randSPeedX.y);


        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;

        rand = Random.Range(randSPeedY.x, randSPeedY.y);

        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _starPosition;
        speed = startSpeed;

    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
