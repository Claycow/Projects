using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB2d;
    private Vector2 Movement;
    private Vector2 playerSpeed;
    private float playerAcceleration = 100f;
    private float MaxSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        playerSpeed += Movement * (playerAcceleration * Time.deltaTime);

        playerSpeed.x = Mathf.Clamp(playerSpeed.x, -MaxSpeed, MaxSpeed);
        playerSpeed.y = Mathf.Clamp(playerSpeed.y, -MaxSpeed, MaxSpeed);

        if (playerSpeed.x > 0 | playerSpeed.x < 0)
        {
            playerSpeed.x *= 0.1f;
        }
        if (playerSpeed.y > 0 | playerSpeed.y < 0)
        {
            playerSpeed.y *= 0.1f;
        }


        print(playerSpeed);
        RB2d.velocity = playerSpeed;
    }
}
