// Script Written By: Liam

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Set the slider for the health bar UI element
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        // Set the max health of the slider
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        // Change the slider to the current health of the player
        slider.value = health;
    }
}
