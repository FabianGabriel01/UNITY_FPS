using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CANVAS : MonoBehaviour
{
    [SerializeField] Text _HealthAmount;


    [Header("TestingPurposes")]
    [SerializeField] KeyCode _TakeDamage= KeyCode.Alpha0;
    [SerializeField] private AudioSource _MyPlayer;
    [SerializeField] private AudioClip _AppleSound, _BatterySound;

    // Start is called before the first frame update
    void Start()
    {
        _HealthAmount.text = SaveScript._PlayerHealth.ToString();

        _MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_TakeDamage)) 
        {
            SaveScript._PlayerHealth -=10;
            _HealthAmount.text = SaveScript._PlayerHealth.ToString();

            if (SaveScript._PlayerHealth <= 0) 
            {
                SaveScript._PlayerHealth = 0;
                _HealthAmount.text = "0";
            }
        }   
    }

    public void OnTakeApples() 
    {
        if (SaveScript._PlayerHealth < 100) 
        {
            SaveScript._Apples -= 1;
            SaveScript._PlayerHealth += 9;
            _HealthAmount.text = SaveScript._PlayerHealth.ToString();

            _MyPlayer.clip = _AppleSound;
            _MyPlayer.Play();

            if (SaveScript._PlayerHealth >= 100) 
            {
                SaveScript._PlayerHealth = 100;
                _HealthAmount.text = "100";

            }

            Debug.Log(SaveScript._Apples);
        }


    }

    public void OnClickBattery() 
    {
        if (SaveScript.BatteryPower < 1.0f) 
        {
            SaveScript._Batteries -= 1;
            SaveScript._NewBatterty = true;

            
            _MyPlayer.clip = _BatterySound;
            _MyPlayer.Play();
        }

    }
}
