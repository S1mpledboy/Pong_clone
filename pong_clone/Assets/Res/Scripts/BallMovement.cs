using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    float movementspeed;
    [SerializeField]
    float speedIncresPerHit;
    [SerializeField]
    float maxSpeed;

    Rigidbody2D Ball;
    float basicSpeed;
    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
       Ball = gameObject.GetComponent<Rigidbody2D>();
        basicSpeed = movementspeed;
       StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall(bool isPlayer1Start = true)
    {
        ResetPositionOfBall(isPlayer1Start);
        this.hitCounter = 0;
        ResetMovementSpeed();
        yield return new WaitForSeconds(1);
        if (isPlayer1Start)
        {
            
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }

    }
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

       this.Ball.velocity = direction * this.movementspeed * Time.fixedDeltaTime;
    }
    public void IncreaseHitCounter()
    {
            this.hitCounter++;
    }
    public void SetMovementSpeed()
    {
        if (this.movementspeed < this.maxSpeed)
        {
            this.movementspeed = this.movementspeed + this.speedIncresPerHit * this.hitCounter;
        }
            
    }
    private void ResetPositionOfBall(bool isPlayer1Start)
    {
        this.Ball.velocity = new Vector2(0, 0);
        if (isPlayer1Start)
        {
            this.Ball.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.Ball.transform.localPosition = new Vector3(100, 0, 0);
        }
    }
    private void ResetMovementSpeed()
    {
        this.movementspeed = this.basicSpeed;
    }
}
