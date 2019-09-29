using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;


    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX) { return; } //return is for if there is no death VFX game should go about as normal
        GameObject deathVFXObject = Instantiate  //Created the GameObject so we could destroy the partle effect (which is the GameObject))
                        (deathVFX, transform.position, transform.rotation)
                        as GameObject;
        Destroy(deathVFXObject, durationOfExplosion);
    }
}
