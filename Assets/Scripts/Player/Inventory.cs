using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private GameObject _InventoryPanel;
    [SerializeField] private bool _InventoryONOFF = false;
    [SerializeField] private KeyCode _KeyInventory = KeyCode.Tab;
    [SerializeField] private GameObject[] _AppleButtons;
    [SerializeField] private GameObject[] _BatteryButtons;

    [Header("Interactions")]
    [SerializeField] private GameObject _HUDOpenText, FlashlightText, NightVisionText;

    // Start is called before the first frame update
    void Start()
    {
        
        

        _InventoryPanel.SetActive(false);
        _InventoryONOFF = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_KeyInventory)) 
        {


            if (_InventoryONOFF == false)
            {
                _HUDOpenText.SetActive(false);
                FlashlightText.SetActive(false);
                NightVisionText.SetActive(false);

                _InventoryPanel.SetActive(true);
                _InventoryONOFF = true;
                CursorMouseON();



                Time.timeScale = 0.0f;

            }
            else if (_InventoryONOFF == true) 
            {
                _HUDOpenText.SetActive(true);
                FlashlightText.SetActive(true);
                NightVisionText.SetActive(true);

                _InventoryPanel.SetActive(false);
                _InventoryONOFF = false;
                CursorMouseOFF();


                Time.timeScale = 1.0f;
            }

           
        }

        CheckAmountApples();
        CheckAmountBatteries();



    }

    private void CursorMouseON() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CursorMouseOFF()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void CheckAmountApples() 
    {
        if (SaveScript._Apples == 0)
        {
            _AppleButtons[0].SetActive(false);
            _AppleButtons[1].SetActive(false);
            _AppleButtons[2].SetActive(false);
            _AppleButtons[3].SetActive(false);
            _AppleButtons[4].SetActive(false);
            _AppleButtons[5].SetActive(false);
        }

        if (SaveScript._Apples == 1)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(false);
            _AppleButtons[2].SetActive(false);
            _AppleButtons[3].SetActive(false);
            _AppleButtons[4].SetActive(false);
            _AppleButtons[5].SetActive(false);
        }



        if (SaveScript._Apples == 2)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(true);
            _AppleButtons[2].SetActive(false);
            _AppleButtons[3].SetActive(false);
            _AppleButtons[4].SetActive(false);
            _AppleButtons[5].SetActive(false);
        }

        if (SaveScript._Apples == 3)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(true);
            _AppleButtons[2].SetActive(true);
            _AppleButtons[3].SetActive(false);
            _AppleButtons[4].SetActive(false);
            _AppleButtons[5].SetActive(false);
        }

        if (SaveScript._Apples == 4)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(true);
            _AppleButtons[2].SetActive(true);
            _AppleButtons[3].SetActive(true);
            _AppleButtons[4].SetActive(false);
            _AppleButtons[5].SetActive(false);
        }

        if (SaveScript._Apples == 5)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(true);
            _AppleButtons[2].SetActive(true);
            _AppleButtons[3].SetActive(true);
            _AppleButtons[4].SetActive(true);
            _AppleButtons[5].SetActive(false);
        }

        if (SaveScript._Apples == 6)
        {
            _AppleButtons[0].SetActive(true);
            _AppleButtons[1].SetActive(true);
            _AppleButtons[2].SetActive(true);
            _AppleButtons[3].SetActive(true);
            _AppleButtons[4].SetActive(true);
            _AppleButtons[5].SetActive(true);
        }

    }

    private void CheckAmountBatteries() 
    {
        if (SaveScript._Batteries == 0) 
        {
            _BatteryButtons[0].SetActive(false);
            _BatteryButtons[1].SetActive(false);
            _BatteryButtons[2].SetActive(false);
            _BatteryButtons[3].SetActive(false);
        }

        if (SaveScript._Batteries == 1)
        {
            _BatteryButtons[0].SetActive(true);
            _BatteryButtons[1].SetActive(false);
            _BatteryButtons[2].SetActive(false);
            _BatteryButtons[3].SetActive(false);
        }

        if (SaveScript._Batteries == 2)
        {
            _BatteryButtons[0].SetActive(true);
            _BatteryButtons[1].SetActive(true);
            _BatteryButtons[2].SetActive(false);
            _BatteryButtons[3].SetActive(false);
        }

        if (SaveScript._Batteries == 3)
        {
            _BatteryButtons[0].SetActive(true);
            _BatteryButtons[1].SetActive(true);
            _BatteryButtons[2].SetActive(true);
            _BatteryButtons[3].SetActive(false);
        }

        if (SaveScript._Batteries == 4)
        {
            _BatteryButtons[0].SetActive(true);
            _BatteryButtons[1].SetActive(true);
            _BatteryButtons[2].SetActive(true);
            _BatteryButtons[3].SetActive(true);
        }
    }
}
