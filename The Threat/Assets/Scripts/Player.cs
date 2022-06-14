using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
    public float BaseDamage;

    public Vector3 Direction;

    public Transform MyRotation;

    public PlayerActions Actions;

    private Animator MyAnimator;

    public GameObject Arm1;
    public GameObject Arm2;

    public bool Holstered;

    [SerializeField]
    private bool _facingRight;



    public static Player Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //_facingRight = true;
        Actions = GetComponent<PlayerActions>();
        Holstered = true;

        MyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        float eulerAngY = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;

        if (Input.GetKeyDown(KeyCode.D) && eulerAngY == 0)
        {

            Debug.Log("Forward1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == -180)
        {
            Debug.Log("Forward2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == 0)
        {

            Debug.Log("BackWard1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.D) && eulerAngY == -180)
        {
            Debug.Log("BackWard2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);
        }

        if (Holstered == false)
        {
            MyAnimator.SetBool("holstered", false);
        }
        else if(Holstered == true)
        {
            MyAnimator.SetBool("holstered", true);
        }



        if (eulerAngY == 180 || eulerAngY == 0)
        {
            Debug.Log("Right!!!!!!!!!!");
            _facingRight = true;
        }
        else if(eulerAngY == -180 )
        {
            Debug.Log("Left!!!!!!!!!!");
            _facingRight = false;
        }

        //GetDirection();

        //if(_facingRight == false)
        //{
        //ChangeDirection();
        //}

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


    public Vector2 GetDirection()
    {
        return _facingRight ? Vector2.right : Vector2.left;
    }

    public void ChangeDirection()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }




}
