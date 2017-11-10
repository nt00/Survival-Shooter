using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int currentWeapon = 0; 

    void Start()
    {
        WeaponSelect();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        // Weapon switching from scroll wheel

        // If the player scrolls up, the weapon will switch
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            // Ensures the weapons keeps looping
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
            // Select next weapon
            currentWeapon++;
        }
        // If player scrolls down, weapon will switch
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            // Ensures the weapons keep looping
            if (currentWeapon <= 0)
                currentWeapon = transform.childCount - 1;
            else
            // Selects previous weapon
                currentWeapon--;
        }

        if(previousWeapon != currentWeapon)
        {
            WeaponSelect();
        }
    }

    void WeaponSelect()
    {
        // Loops through the weapons to switch them
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
