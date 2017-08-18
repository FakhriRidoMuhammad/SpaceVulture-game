using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100;
    public AudioClip laserAudio;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(laserAudio, transform.position);
    }

    public float Damage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
