using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider) //otherCollider = the thing we collided with collider
    {
        GameObject otherObject = otherCollider.gameObject;    //I know about the game object I just bumped into
        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }

    }
}
