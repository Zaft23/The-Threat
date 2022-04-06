using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon Weapon;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            target.GetComponent<PlayerActions>().CurrentWeapon = Weapon;
            target.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = Weapon.Artwork;
            Destroy(gameObject);
        }
    }



}
