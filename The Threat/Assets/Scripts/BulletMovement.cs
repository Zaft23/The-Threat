using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //public Weapon CurrentWeapon;

    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb2d;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _rb2d = GetComponent<Rigidbody2D>();
        _mousePos = _mainCam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = _mousePos - transform.position;
        Vector3 rotation = transform.position - _mousePos;
        _rb2d.velocity = new Vector2(direction.x, direction.y).normalized * Force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
