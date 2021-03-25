/**
* AUTHOR NAME: Eric Goulet
* PROJECT: Save Bonnie (Zombie Tower Defense Game)
* 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class adds the healthbar functionality for the zombies
 */
public class HealthBar : MonoBehaviour
{

    public Slider slider; //holds the value of the slider that depicts the zombies health

    /*
     * This function sets the value of the zombies max health
     * @param health  the value to set maxHealth to
     */
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    /*
     * This function sets the current value of the zombies health
     * @param health  the value to set health to
     */
    public void setHealth(int health)
    {
        slider.value = health;
    }
}
