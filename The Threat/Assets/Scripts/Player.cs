using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
   
    public static Player Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void TakeDamage(float Damage)
    {

        Health -= Damage;

        //do animation

        if (Health <= 0)
        {
            Debug.Log("i die");
            //Die();
        }

    }

}
