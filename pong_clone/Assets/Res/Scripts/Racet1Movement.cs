
using UnityEngine;



public class Racet1Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    Rigidbody2D Racet;


    private void FixedUpdate()
    {
        this.RacetMove();

    }
    private void RacetMove()
    {      
        float vertcicalInput = Input.GetAxisRaw("Vertical");
        this.Racet.velocity = new Vector2(0, vertcicalInput) * movementSpeed * Time.deltaTime;
    }
}
