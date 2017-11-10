using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerUtility))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 6f;
    public float mouseSensitivity = 6f;
    [SerializeField]
    private int jumpMax = 2;
    private int jumpCount;
    private bool grounded;

    public float health = 100f;


    private PlayerUtility utility;

    void Awake()
    {
        // Reference to PlayerUtility script
        utility = GetComponent<PlayerUtility>();
        jumpCount = jumpMax;
    }

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        CameraRotation();
        // If player falls off the platform, they will die
        if (transform.position.y < -2)
        {
            PlayerDeath();
        }
        // If player uses space key, player will jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    void PlayerMovement()
    {
        //Grabbing input
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        //Getting local direction
        Vector3 moveHorizontal = transform.right * inputHorizontal;
        Vector3 moveVertical = transform.forward * inputVertical;

        //Preventing varying speeds, keeping vectors as directions only
        Vector3 movevelocity = (moveHorizontal + moveVertical).normalized * movementSpeed;

        //Apply player movement
        utility.Move(movevelocity);

    }

    void PlayerRotation()
    {
        //Grabbing input
        float yRotation = Input.GetAxisRaw("Mouse X");

        //Storing rotation, affected by mouse sensitvity variable
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * mouseSensitivity;

        //Applying player rotation
        utility.Rotate(rotation);
    }

    void CameraRotation()
    {
        //Grabbing input
        float xRotation = Input.GetAxisRaw("Mouse Y");

        //Storing rotation, affected by mouse sensitvity variable
        float cameraRotationX = xRotation * mouseSensitivity;

        //Applying camera rotation
        utility.CameraRotate(cameraRotationX);
    }

    void PlayerJump()
    {
        //If player has jumped once or more, player is not grounded and avaliable jumps are subtracted
        if (jumpCount > 0)
        {
            utility.Jump();
            grounded = false;
            jumpCount = jumpCount - 1;
        }
        //if the player has used all jumps, this function is restarted
        if (jumpCount == 0)
        {
            return;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a gameobject with the tag 'Ground', the player is grounded and they can jump again
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = jumpMax;
            grounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If player comes in contact with a gameobject with the tag "Enemy", the player dies
        if (other.transform.tag == "Enemy")
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        //Excecuting death function
        utility.Die();
    }

}
