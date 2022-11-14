using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    public void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other) {
        gameObject.SetActive(false);

        if(other.collider.tag == "Player")
        {
            playerStats.takeDamage(playerStats.damage);
        } 
        else if(other.collider.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
