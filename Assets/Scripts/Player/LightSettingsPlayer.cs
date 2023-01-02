using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class LightSettingsPlayer : MonoBehaviour
{
    [Header("NightVision")]
    [SerializeField] PostProcessVolume _Volume;
    [SerializeField] PostProcessProfile[] _NightVisionOnOff;
    [HideInInspector] private bool _NightVisionToggle = false, _FlashLightToggle = false;
    [SerializeField] GameObject _NightVisionObj, _FlashLightObj;
    [SerializeField] Animator _Anims;
    [SerializeField] private float _TimerAnims = 1.5f;
    [SerializeField] private GameObject _Light, _LightObj;

    [Header("Inputs")]
    [SerializeField] KeyCode _NightVisionKey = KeyCode.N;
    [SerializeField] KeyCode _FlashLightKey = KeyCode.F;


    [Header("BatterySYSTEM")]
    [SerializeField] Image _BatteryUI;
    [SerializeField] private float _DrainTime = 10.0f, _Power = 1.0f;
    [SerializeField] private bool _IsActive = false;

    private void Awake()
    {
        _NightVisionObj.SetActive(false);
        _FlashLightObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(_NightVisionKey))
        {
            if (_NightVisionToggle == false)
            {
                _Volume.profile = _NightVisionOnOff[1];
                _NightVisionObj.SetActive(true);
                _NightVisionToggle = true;
                _IsActive = true;
            }
            else
            {
                _Volume.profile = _NightVisionOnOff[0];
                _NightVisionObj.SetActive(false);
                _NightVisionToggle = false;
                _IsActive = false;
            }
        }


        if (Input.GetKeyDown(_FlashLightKey))
        {

            if (_FlashLightToggle == false)
            {
                StartCoroutine(TurnON());
                AnimFlashLightON();

            }
            else
            {

                StartCoroutine(TurnOFF());
                AnimFlashLightOFF();



            }
        }




        if (_FlashLightToggle || _NightVisionToggle ) 
        {
            if (_IsActive) BatteryImage();

            if (_Power <= 0) 
            {
                _IsActive = false;
                _Light.SetActive(false);
                _Power = 0;


                _Volume.profile = _NightVisionOnOff[0];
                _NightVisionObj.SetActive(false);
                _NightVisionToggle = false;

            }

        }

        if (SaveScript._NewBatterty == true) 
        {
            _Power = 1.0f;
            _BatteryUI.fillAmount = 1.0f;
            _Light.SetActive(true);
            _IsActive = true;
            SaveScript._NewBatterty = false;

        }






    }

    IEnumerator TurnOFF()
    {
        _Light.SetActive(false);
        _LightObj.SetActive(true);
        _IsActive = false;

        yield return new WaitForSeconds(_TimerAnims);

        _FlashLightObj.SetActive(false);
        _FlashLightToggle = false;
    }

    IEnumerator TurnON()
    {
        _FlashLightObj.SetActive(true);
        _FlashLightToggle = true;
        _Light.SetActive(false);
        _LightObj.SetActive(true);

        yield return new WaitForSeconds(_TimerAnims);

        _Light.SetActive(true);
        _IsActive = true;

    }

    private void AnimFlashLightON()
    {
        _Anims.SetBool("FlashLightONOFF", true);
    }

    private void AnimFlashLightOFF()
    {
        _Anims.SetBool("FlashLightONOFF", false);
    }


    private void BatteryImage() 
    {
        _BatteryUI.fillAmount -= 1.0f / _DrainTime * Time.deltaTime;
        _Power = _BatteryUI.fillAmount;
        SaveScript.BatteryPower = _Power;


    }
}
