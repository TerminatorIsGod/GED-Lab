using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score;
    public int heal;

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player"){
            if (score != 0)
                ScoreManager.instance.ChangeScore(score);
            if (heal != 0)
                PlayerManager.instance.player.GetComponent<CharacterStats>().recoverHealth(heal);

            Destroy(gameObject);
        }  
    }
}
