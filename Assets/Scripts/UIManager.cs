using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

   
    [SerializeField] private Slider _foodSlider, _healthSlider, _oxygenSlider;
     private Button _addFood, _addOxygen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliderValues();
        StatsDrop();

    }
    private void UpdateSliderValues()
    {
        _foodSlider.value = GameManager.Instance._playerFood;
        _healthSlider.value = GameManager.Instance._playerHealth;
        _oxygenSlider.value = GameManager.Instance._playerOxygen;
    }

    private void StatsDrop()
    {
        SetMaxValues();

        
        //FOOD
        GameManager.Instance._playerFood -= Time.deltaTime * 7;

        //Oxygen
        GameManager.Instance._playerOxygen -= Time.deltaTime * 7;

        //Health
        if(GameManager.Instance._playerFood <= 0 && GameManager.Instance._playerOxygen <= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 6;
        }

        if (GameManager.Instance._playerFood <= 0 && GameManager.Instance._playerOxygen >= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 2;
        }

        if (GameManager.Instance._playerFood >= 0 && GameManager.Instance._playerOxygen <= 0)
        {
            GameManager.Instance._playerHealth -= Time.deltaTime * 4;
        }

    }

    public void AddFood(int value)
    {
        GameManager.Instance._playerFood += value;
    }
    public void AddOxygen(int value)
    {
        GameManager.Instance._playerOxygen += value;
    }
    private void SetMaxValues()
    {
        //Set food to 100 if food is over 100
        GameManager.Instance._playerFood = (GameManager.Instance._playerFood >= 100) ? 100 : GameManager.Instance._playerFood;
        //Set food to 0 if food is under 0
        GameManager.Instance._playerFood = (GameManager.Instance._playerFood <= 0) ? 0 : GameManager.Instance._playerFood;

        //Set health to 100 if health is over 100
        GameManager.Instance._playerHealth = (GameManager.Instance._playerHealth >= 100) ? 100 : GameManager.Instance._playerHealth;
        //Set health to 0 if health is under 0
        GameManager.Instance._playerHealth = (GameManager.Instance._playerHealth <= 0) ? 0 : GameManager.Instance._playerHealth;


        //Set Oxygen to 100 if oxygen is over 100
        GameManager.Instance._playerOxygen = (GameManager.Instance._playerOxygen >= 100) ? 100 : GameManager.Instance._playerOxygen;
        //Set Oxygen to 0 if Oxygen is under 0
        GameManager.Instance._playerOxygen = (GameManager.Instance._playerOxygen <= 0) ? 0 : GameManager.Instance._playerOxygen;
    }

}
