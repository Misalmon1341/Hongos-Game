using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    public float movh;
    public float playerSpeed;
    public float playerRotate;
    private Rigidbody rb;
    [Header("Jump")]
    public float jumpSpeed;
    private Vector3 displacement;
    [Header("Ground")]
    public bool checkGround = true;
    public Transform chkGround;

   

    //[Header("WallJump")]
  

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    private void FixedUpdate()
    {
        float movh = Input.GetAxis("Horizontal");
        PlayerMove(movh);
        PlayerJump();
    }

    private void PlayerMove(float movh)
    {
        displacement.Set(movh, 0f, 0f);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + displacement);

        if (movh != 0f)
        {
            PlayerRotate(movh);
        }
    }

    private void PlayerRotate(float movh)
    {
        float interpolation = playerRotate * Time.deltaTime;
        Vector3 targetDirection = new Vector3(0f, 0f, movh);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, interpolation);
        rb.MoveRotation(newRotation);
    }

    private void PlayerJump()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        if (Input.GetButton("Jump") && checkGround)
        {
            rb.velocity = new Vector3(0f, jumpSpeed, 0f);
            checkGround = false;
        }

        if (Physics.Raycast(chkGround.position, down, out hit, 0.2f) && hit.collider.CompareTag("Ground"))
        {
            checkGround = true;
        }
        else
        {
            checkGround = false;
        }
    }

}
