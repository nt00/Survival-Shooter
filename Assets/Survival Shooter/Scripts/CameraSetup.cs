using UnityEngine;
using UnityEngine.Networking;

public class CameraSetup : NetworkBehaviour
{
    Camera sceneCamera;

    void Start()
    {
        if(isLocalPlayer)
        {
            // Disables the scene camera if we are local user
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        // Re-enables the scene camera
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
