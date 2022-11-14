using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public Animator animator;

    public override void dead()
    {
        base.dead();

        animator.SetTrigger("isDead");

        Invoke("reloadScene", 3);
    }

    void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
