using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] int hitCountToDie = 1;
    private int hitCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        hitCounter++;
        if (hitCounter >= hitCountToDie)
        {
            Die();
        }
    }

    private void Die()
    {
        //Stop movement
        //particle pooff yada kan
        Destroy(parentObject);
    }
}
