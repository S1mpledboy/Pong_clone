using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColisionController : MonoBehaviour
{   [SerializeField]
    BallMovement ballMovement;
    [SerializeField]
    ScoreSystem scoreController;

    Vector3 ballPosition;

    
    void BouncefromRacet(Collision2D collision2D)
    {
        ballPosition = this.transform.position;
        Vector3 racetPosition = collision2D.gameObject.transform.position;

        float racetHight = collision2D.collider.bounds.size.y;
        float y = (ballPosition.y - racetPosition.y) / racetHight;
        float x;
        if(collision2D.gameObject.name == "Player1Racet")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x,y));
        this.ballMovement.SetMovementSpeed();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1Racet"|| collision.gameObject.name == "Player2Racet")
        {
            this.BouncefromRacet(collision);
        }
        else if(collision.gameObject.name == "LeftWall")
        {
            this.scoreController.ChangeScore("player2");
            this.scoreController.CheckWinConditions();
            StartCoroutine(this.ballMovement.StartBall(true));

        }
        else if(collision.gameObject.name == "RigthWall")
        {
            this.scoreController.ChangeScore("player1");
            this.scoreController.CheckWinConditions();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
