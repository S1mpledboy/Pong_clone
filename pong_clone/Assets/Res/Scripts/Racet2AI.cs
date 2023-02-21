using TMPro;
using UnityEngine;

public class Racet2AI : MonoBehaviour
{
    public float movementspeed;
    public GameObject ball;
    public int AIbuff;
    private Rigidbody2D racetRigidbody;
   
    GameObject uiTxtScorePlayer2;

    private void Awake()
    {
        racetRigidbody = GetComponent<Rigidbody2D>();
        SetPlayerNameToAI();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnablePlayer2();
        }
    }

    private void FixedUpdate()
    {
        MoveAIRacet();
    }

    private void EnablePlayer2()
    {
        this.GetComponent<Racet2Movement>().enabled = true;
        DisableAI();
    }

    private void DisableAI()
    {
        this.enabled = false;
    }

    private void SetPlayerNameToAI()
    {
        uiTxtScorePlayer2 = GameObject.FindGameObjectWithTag("Player2");
        uiTxtScorePlayer2.GetComponent<TextMeshProUGUI>().text = "AI, Press ENTER to join";
    }

    private void MoveAIRacet()
    {
        if (Mathf.Abs(this.transform.position.y - this.ball.transform.position.y) > 50)
        {
            if (this.transform.position.y < this.ball.transform.position.y)
            {
                racetRigidbody.velocity = new Vector2(0, 1) * movementspeed * Time.fixedDeltaTime * AIbuff;
            }
            else
            {
                racetRigidbody.velocity = new Vector2(0, -1) * movementspeed * Time.fixedDeltaTime * AIbuff;
            }
        }
        else
        {
            racetRigidbody.velocity = new Vector2(0, 0);
        }
    }
}
