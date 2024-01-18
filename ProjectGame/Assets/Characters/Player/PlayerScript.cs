using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    private Vector2 Movement;
    private Vector2 MovDirection;
    private float playerSpeed = 10.0f;
    private float MaxSpeed = 20.0f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 3.0f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private Camera MainCamera;
    [SerializeField] private Rigidbody2D RB2d;
    [SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDashing) 
        {
            return;
        }

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        Movement = (Movement * playerSpeed);

        Movement.x = Mathf.Clamp(Movement.x, -MaxSpeed, MaxSpeed);
        Movement.y = Mathf.Clamp(Movement.y, -MaxSpeed, MaxSpeed);


        RB2d.velocity = Movement;

        if (Input.GetKeyDown(KeyCode.Space) && canDash) 
        {
            StartCoroutine(Dash());
        }

    }

    private void FixedUpdate()
    {
        if (isDashing) 
        {
            return;
        }
    }

    private IEnumerator Dash()
    {
        print("DASHHHHH");


        canDash = false;
        isDashing = true;
        RB2d.velocity = Movement * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
