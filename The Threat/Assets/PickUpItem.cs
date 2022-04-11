using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon Weapon;

    private void Start()
    {
        StartCoroutine(DestroyGun());
    }

    //private void OnCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Player")
    //    {

    //        Destroy(gameObject);

    //    }

    //}

    //number of mags / bullet remember

    private IEnumerator DestroyGun()
    {
        float time = 10f;
        yield return new WaitForSeconds(time);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);

    }





}
