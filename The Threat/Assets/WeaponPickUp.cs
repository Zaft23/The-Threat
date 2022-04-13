using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon Weapon;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    //private void OnCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Player")
    //    {

    //        Destroy(gameObject);

    //    }

    //}

    //number of mags / bullet remember

    private IEnumerator DestroyObject()
    {
        float time = 10f;
        yield return new WaitForSeconds(time);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);

    }





}
