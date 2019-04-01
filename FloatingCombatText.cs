﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DisplayMode {RegularDamage,Retaliation,Lifesteal,Heal,AbilityDamage}
public class FloatingCombatText : MonoBehaviour
{


    public DamageReport dmgReport;
    public string ExtraDisplayString;
    public DisplayMode displayMode;
    // Start is called before the first frame update
    void Start()
    {
        if (dmgReport.primaryDamageDealt < 0)
        {
            dmgReport.primaryDamageDealt = 0;
        }

        dmgReport.primaryDamageDealt = Mathf.Round(dmgReport.primaryDamageDealt);
        dmgReport.lifeStealHeal = Mathf.Round(dmgReport.lifeStealHeal);
        dmgReport.retaliationDamageRecieved = Mathf.Round(dmgReport.retaliationDamageRecieved);

        TextMesh textmesh = this.GetComponent<TextMesh>();

        if (displayMode == DisplayMode.Retaliation)
        {
            textmesh.text = "" + dmgReport.retaliationDamageRecieved;
        }
        else if (displayMode == DisplayMode.Heal)
        {
            textmesh.text = "" + dmgReport.primaryDamageDealt;
        }
        else if (displayMode == DisplayMode.Lifesteal)
        {
            textmesh.text = "" + dmgReport.lifeStealHeal;
        }
        else if (displayMode == DisplayMode.RegularDamage)
        {
            textmesh.text = "" + dmgReport.primaryDamageDealt;
        }
        else if (displayMode == DisplayMode.AbilityDamage)
        {
            textmesh.text = "" + dmgReport.primaryDamageDealt;
        }

        if (dmgReport.wasCriticalStrike)
        {
            ExtraDisplayString = "CRIT";
        }
        else if (dmgReport.wasMiss)
        {
            ExtraDisplayString = "MISS";
        }
        else if (dmgReport.wasDampenedMiss)
        {
            ExtraDisplayString = "DAMPENED";
        }
        if (ExtraDisplayString != "")
        {
            textmesh.text += " (" + ExtraDisplayString + ")";
        }

        if (displayMode == DisplayMode.RegularDamage || displayMode == DisplayMode.AbilityDamage || displayMode == DisplayMode.Retaliation)
        {
            //adapt floating combat text colors
            if (dmgReport.damageSourceNPC.isEnemy == true || displayMode == DisplayMode.Retaliation) // enemy attacks are always red
            {
                textmesh.color = Color.red;
            }
            else if (dmgReport.damageSourceNPC.isEnemy == false) // human attack
            {
                if (displayMode == DisplayMode.RegularDamage)  // auto attacks
                {
                    textmesh.color = Color.white; // auto attacks are white
                }
                  
                    else if (displayMode == DisplayMode.AbilityDamage)
                {
                    textmesh.color = Color.yellow;
                }
            }
        
        }

        else if (displayMode == DisplayMode.Lifesteal || displayMode == DisplayMode.Heal)
        {
              
                textmesh.color = Color.green;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation; // "billboard"
    }
}
