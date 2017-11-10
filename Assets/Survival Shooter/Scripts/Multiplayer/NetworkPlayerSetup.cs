using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] disabledComponents;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    void Start()
    {
        // If we are not local player, components will be disabled and remote layer will be assigned
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemoteLayer();
        }

        RegisterPlayer();

    }

    void RegisterPlayer()
    {
        //Getting Reference to Network Identity
        string _ID = "Player" + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }
    void DisableComponents()
    {
        // Disables components within array if we are not the local player
        for (int i = 0; i < disabledComponents.Length; i++)
        {
            disabledComponents[i].enabled = false;
        }
    }

    void AssignRemoteLayer()
    {
        // Convert name of layer as string back to integer
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
}
