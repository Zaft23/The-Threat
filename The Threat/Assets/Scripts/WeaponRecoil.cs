using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [Header("Weapon Recoil")]
    public Vector3 UpRecoil;
    Vector3 originalRotation;



    // Start is called before the first frame update
    void Start()
    {

        originalRotation = transform.localEulerAngles;


    }
    private void Update()
    {
        
    }





    #region Give Gun recoil

    public void AddRecoil()
    {
        transform.localEulerAngles += UpRecoil;
    }

    public void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }



    #endregion
    // Update is called once per frame





}
