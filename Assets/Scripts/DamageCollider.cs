using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider) 
        //nothing in () because we aren't trying to figure out what bumped into it
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        //FindObjectOfType Accesses another script then . to call a method in script
        Destroy(otherCollider.gameObject);

    }


}
