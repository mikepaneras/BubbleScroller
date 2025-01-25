using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] Image barFillImage;
    const float TOTAL_ENERGY = 100;
    float currentEnergy;
    [SerializeField] float depletionSpeed = 1;
    [SerializeField] float refillSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = TOTAL_ENERGY;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressing Space");
            if(currentEnergy > 0 )
            {
                currentEnergy -= Time.deltaTime * depletionSpeed;
                if (currentEnergy < 0)
                {
                    currentEnergy = 0;
                }
            }
        }
        else
        {
            if(currentEnergy < TOTAL_ENERGY)
            {
                currentEnergy += Time.deltaTime * refillSpeed;
                if(currentEnergy > TOTAL_ENERGY)
                {
                    currentEnergy = TOTAL_ENERGY;
                }
            }
        }
        barFillImage.fillAmount =  currentEnergy / TOTAL_ENERGY;
    }
    public float GetCurrentEnergy() => currentEnergy;
    public void DecreaseEnergy(int amount)
    {
        currentEnergy -= amount;

        if( currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }
    public void IncreaseEnergy(int amount)
    {
        currentEnergy += amount;

        if (currentEnergy > TOTAL_ENERGY)
        {
            currentEnergy = TOTAL_ENERGY;
        }
    }
}
