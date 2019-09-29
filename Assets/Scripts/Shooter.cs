using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;   
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>(); //accessing Animator and calling it animator
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {            
            animator.SetBool("isAttacking", true);            
        }
        else
        {
            animator.SetBool("isAttacking", false);            
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();  //an array [] to store all of the AttackerSpawners

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough =
                (Mathf.Abs(spawner.transform.position.y /*spawner position*/
                - transform.position.y) /*shooter (whoever has the script) position)*/
                <= Mathf.Epsilon/*epsilon means smallest nunmber */); 
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

        //if my lane spawner child cound is less than or equal to 0
            //then return false

    }



    public void Fire()
    {
        GameObject newProjectile = 
            Instantiate(projectile, gun.transform.position, Quaternion.identity)
            as GameObject;  //need this as a GameObject so we can place it within heirarchy and manipulate it
        newProjectile.transform.parent = projectileParent.transform;
        
    }
    
}
