using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D playerColidedWith)
    {
        PlayerController player = playerColidedWith.GetComponent<PlayerController>();
        if (player)
        {
            SpriteRenderer PUtype = GetComponent<SpriteRenderer>();

            if (PUtype.sprite.name == "PUhealth")
            {
                PlayerController.health += 100;
                Debug.Log("Health: "+PlayerController.health);
                Destroy(gameObject);
            }
            if (PUtype.sprite.name == "PUspeed")
            {
                PlayerController.moveSensitivity += 0.5f;
                Debug.Log("moveSpeed: "+ PlayerController.moveSensitivity);
                Destroy(gameObject);
            }
            if (PUtype.sprite.name == "PUfire")
            {
                PlayerController.firingRate -= 0.02f;
                Debug.Log("firingRate: " + PlayerController.firingRate);
                Destroy(gameObject);
            }
        }
    }

}

