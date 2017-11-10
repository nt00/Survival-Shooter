using UnityEngine;
using UnityEngine.Networking;

public class InsectSprayWeapon : NetworkBehaviour
{
    [SerializeField]
    private float range = 25f;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private Camera shooterCam;
    private float fireRate = 0.75f;
    private float damage = 40f;
    private float nextTimeToFire = 0f;
    private int shotgunFrag = 8;
    private float bulletSpread = 10f;
    private float impactForce = 40f;

    RaycastHit hit;

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
        for (int i = 0; i < shotgunFrag; i++)
        {
            RaycastHit hit;

            Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

            Quaternion randomRotation = Random.rotation;

            fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(0.0f, bulletSpread));

            if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, range, mask))
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
}
