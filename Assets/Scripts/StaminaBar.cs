using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 100;
    private float currentStamina;

    private  WaitForSeconds regenTick = new  WaitForSeconds(0.1f);
    private Coroutine regen;
    public static StaminaBar instance;
    public static bool hasStamina = true;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void  useStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
            hasStamina = true;
        }
        else
        {
            hasStamina = false;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            if(currentStamina == maxStamina)
                hasStamina = true;
            yield return regenTick;
        }
        regen = null;
    }
}
