using TMPro;
using UnityEngine;

public class Racet2Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    Rigidbody2D Racet;

    GameObject uiTxtScorePlayer2;

    private void OnEnable()
    {
        SetPlayer2Name();
    }
    private void FixedUpdate()
    {
        this.RacetMove();
    }
    private void RacetMove()
    {
        float vertcicalInput = Input.GetAxisRaw("Vertical2");
        this.Racet.velocity = new Vector2(0, vertcicalInput) * movementSpeed * Time.fixedDeltaTime;
    }
    private void SetPlayer2Name()
    {
        uiTxtScorePlayer2 = GameObject.FindGameObjectWithTag("Player2");
        uiTxtScorePlayer2.GetComponent<TextMeshProUGUI>().text = "Player2";
    }
}
