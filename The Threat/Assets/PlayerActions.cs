using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{


    private Inventory _inventory;
    private InventoryManager _manager;

    public Transform FirePoint;
    float lookAngle;

    private float _nextTimeOfFire = 0;

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            Weapon newItem = target.transform.GetComponent<PickUpItem>().Weapon;
            _inventory.AddItem(newItem);
            Destroy(target.transform.gameObject);

        }

    }

    private void OnApplicationQuit()
    {
      
    }

    void Start()
    {
        GetRefrences();
        
        

    }

    void Update()
    {
        Vector3 gunPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gunPose.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= _nextTimeOfFire)
            {
              
            }
        }

        if(Input.GetButton("Throw"))
        {

        }


    }

    public void IsShooting()
    {
       
    }

    //throw gun: there's probably a better and efficient way of doing this.. but Too Bad!
    public void IsThrowingGun()
    {
        //private speed var
        //current item to null
        //InstaantiateWeapon


    }


    private void GetRefrences()
    {
        _inventory = GetComponent<Inventory>();
    }


}

