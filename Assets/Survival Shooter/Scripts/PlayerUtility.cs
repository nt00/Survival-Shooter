using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerUtility : MonoBehaviour
{
    [SerializeField]
    private Camera camera01;
    [SerializeField]
    private float cameraClamp = 50f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private float jumpStrength = 5f;
    private bool cursorVisible = true;


    private Rigidbody rigid;

    void Awake()
    {
        //Referencing Rigidbody
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Initially start the game with the cursor locked and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Hiding and Showing mouse with escape toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(cursorVisible == true)
            {
                // Unlocks the cursor and becomes visible
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if(cursorVisible == false)
            {
                // Locks the cursor and becomes invisible
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            cursorVisible = !cursorVisible;
        }
    }

    void FixedUpdate()
    {
        ExecuteMovement();
        ExecuteRotation();
    }

    //Grabs a movment vector
    public void Move(Vector3 movevelocity)
    {
        velocity = movevelocity;
    }
    //Rotational vector
    public void Rotate(Vector3 vRotation)
    {
        rotation = vRotation;
    }
    //Rotational vector for camera
    public void CameraRotate(float cRotationX)
    {
        cameraRotationX = cRotationX;
    }

    // Performs movment
    void ExecuteMovement()
    {
        // if the player wants to move
        if (velocity != Vector3.zero)
        {
            // Move player to position + velocity
            rigid.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
    }
    // Performs rotation
    void ExecuteRotation()
    {
        rigid.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        //if we have a camera in scene
        if (camera01 != null)
        {
            //Applying the value to current camera rotation
            currentCameraRotationX -= cameraRotationX;
            //Preventing the camera from over-rotating by clamping it
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraClamp, cameraClamp);
            //Appy to transform
            camera01.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
    public void Jump()
    {
        //Player jump using force on the rigidbody
        rigid.AddForce(jumpStrength * transform.up, ForceMode.Impulse);
    }

    public void Die()
    {
        // When player dies loads into end screen
        SceneManager.LoadScene(2);
    }
}
