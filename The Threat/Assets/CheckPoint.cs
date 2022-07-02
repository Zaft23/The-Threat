using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool IsInRange;
    private GameObject GM;
    TestSaveAndLoad save;
    // Start is called before the first frame update
    void Start()
    {
         GM = GameObject.FindGameObjectWithTag("GameMaster");
        save = GM.GetComponent<TestSaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange)
        {
            //save
            save.SavePlayer();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   


        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
        }

    }


}
