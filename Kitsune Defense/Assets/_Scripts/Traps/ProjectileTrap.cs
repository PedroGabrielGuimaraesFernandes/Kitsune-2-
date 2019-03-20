﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrap : Trap
{
    public Transform reference;
    public ParticleSystem[] shootPosition;
    public float maxNumShoot=16;

    private int attackIndex;

    // Start is called before the first frame update
    void Start()
    {
        //attackIndex = Animator.StringToHash("attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        for (int i = 0; i < maxNumShoot; i++)
        {
            int r = Random.Range(0, 12);
            shootPosition[r].Emit(1);
            Debug.Log("Particule System" + r + "para i num" + i);
        }
        ReloadTrap(reloadTime);
    }

    public void ReloadTrap(float tempo)
    {
        StartCoroutine(ReloadTimer(tempo));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position,gameObject.transform.position + reference.transform.up * 6);

        //Gizmos.

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && reloading == false) {
            reloading = true;
            Debug.Log("Kunai Trap Activated");
            Shoot();
            //anim.SetTrigger(attackIndex);
        }

        /*IABase enemyScript = other.transform.GetComponent<IABase>();
        CauseDamage(enemyScript);*/

    }

    public IEnumerator ReloadTimer(float time)
    {
        float r = 0;
        while (r < reloadTime)
        {
            r++;
            yield return new WaitForSeconds(1f);
        }
        reloading = false;
    }
}
