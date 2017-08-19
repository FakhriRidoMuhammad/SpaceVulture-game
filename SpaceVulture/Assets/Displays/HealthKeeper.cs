using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour {

    private Text healthText;

	void Start () {
        healthText = GetComponent<Text>();
	}
	
	void Update () {
        DisplayHealth();
	}

    private void DisplayHealth()
    {
        healthText.text = ("Health: " + PlayerController.health);
    }

    public static void ResetHealth()
    {
        PlayerController.health = 300;
    }
}
