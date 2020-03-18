﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{

    public int currentHealth;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Die();
        }

        if(playerInRange && Input.GetKeyDown(KeyCode.LeftShift)){
            currentHealth -= (25 - defense);
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(waiter());
        }
    }

    override public void Die(){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    IEnumerator waiter()
    {
        int wait_time = Random.Range(0, 2);
        yield return new WaitForSeconds(wait_time);
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
    }
}