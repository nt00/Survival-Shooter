using UnityEngine;
using UnityEngine.Networking;

public class WaterGunWeapon : NetworkBehaviour
{
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private Camera shooterCam;
    private float fireRate = 0.5f;
    private float damage = 50f;
    private float nextTimeToFire = 0f;
    private float impactForce = 20f;
    [SerializeField]
    private LayerMask mask;

    public GameObject hitEffect;

    void Update()
    {
        // When bullet is fired, there is a delay before next shot can be fired
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        //Storing information about what we hit
        RaycastHit hit;

        // If the raycast hits the objecct that the camera is facing
        if (Physics.Raycast(shooterCam.transform.position, shooterCam.transform.forward, out hit, range, mask))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            //If we have found an enemy, it will take damage
            if (enemy != null)
            {
                enemy.GunDamage(damage);
            }

            // If there is a rigidbody on the object we have hit, the object will be affected by the force of the impact
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            // Creating a hit effect when we hit an object
            GameObject impactHitEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactHitEffect, 0.5f);

        }
    }
}
