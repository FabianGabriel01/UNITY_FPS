using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private Ray _RayHit;
    [SerializeField] private KeyCode _Interactions = KeyCode.E;
    [SerializeField] private float _rayDistance = 5.0f;
    private Vector3 _Direction = Vector3.forward;

    [Header("APPLES")]
    [SerializeField] private GameObject _ObjMessageApples;
    [SerializeField] private GameObject _ObjMaxSlotsApples;
    [SerializeField] private bool _CanPickApples = true;


    [Header("BATTERIES")]
    [SerializeField] private GameObject _ObjMessageBattery;
    [SerializeField] private GameObject _ObjMaxSlotsBatteries;
    [SerializeField] private bool _CanPickBatteries = true;


    [Header("Sounds")]
    [SerializeField] private AudioSource _MyPlayer;
    [SerializeField] private AudioClip[] _OnPickUp;



    //[SerializeField] private Apple _RefApple;


    // Update is called once per frame
    void Update()
    {

       
            _RayHit = new Ray(transform.position, transform.TransformDirection(_Direction * _rayDistance));
            Debug.DrawRay(transform.position, transform.TransformDirection(_Direction * _rayDistance));

            if (Physics.Raycast(_RayHit, out RaycastHit _Hit, _rayDistance))
            {

                /////////////////////////////////////////////////////////////////
                //APPLES
                //Debug.Log(_Hit.collider.tag);
                if (_Hit.transform.tag == "Apple")
                {
                    _ObjMessageApples.SetActive(true);

                    if (SaveScript._Apples == 6)
                    {
                        _ObjMaxSlotsApples.SetActive(true);
                        _CanPickApples = false;
                    }
                    else 
                    {
                        _CanPickApples = true;

                    }

                }
                else 
                {
                    _ObjMessageApples.SetActive(false);
                    _ObjMaxSlotsApples.SetActive(false);
                }

                


                if (Input.GetKeyDown(_Interactions) && _CanPickApples == true)
                { 

                    if (_Hit.collider.tag == "Apple") 
                    {
                        SaveScript._Apples+=1;
                        Debug.Log(SaveScript._Apples);


                        _MyPlayer.clip = _OnPickUp[Random.Range(0, 2)];
                        _MyPlayer.Play();

                        Destroy(_Hit.transform.gameObject);

                    }    
            
                }
                //////////////////////////////////////////////////////////////



                ////////////////////////////////////////////////////////////
                //BAtteries
                if (_Hit.transform.tag == "Battery")
                {
                    _ObjMessageBattery.SetActive(true);

                    if (SaveScript._Batteries == 4)
                    {
                        _ObjMaxSlotsBatteries.SetActive(true);
                        _CanPickBatteries = false;
                    }
                    else
                    {
                        _CanPickBatteries = true;

                    }

                }
                else
                {
                    _ObjMessageBattery.SetActive(false);
                    _ObjMaxSlotsBatteries.SetActive(false);
                }




                if (Input.GetKeyDown(_Interactions) && _CanPickBatteries == true)
                {

                    if (_Hit.collider.tag == "Battery")
                    {
                        SaveScript._Batteries += 1;
                        Debug.Log(SaveScript._Batteries);

                        _MyPlayer.clip = _OnPickUp[Random.Range(0, 2)];
                        _MyPlayer.Play();

                    Destroy(_Hit.transform.gameObject);
                    }

                }
                //////////////////////////////////////////////////////




                //AddIMPULSE
                if (Input.GetKeyDown(_Interactions))
                    {
                        if (_Hit.rigidbody == null)
                        {
                            Debug.Log("SinRigidBody");
                        }
                        else 
                        {
                            Debug.Log("RigidBody");

                            _Hit.rigidbody.AddForce( _RayHit.direction * 50 , ForceMode.Impulse);
                        }

                    }



            

            }



    }
}
