using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float currentHealth;
    public float maxHealth = 100f;

    //Debug
    private TextMesh text;


	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;

        //Debug
        text = GetComponentInChildren<TextMesh>();
        if(text)
        {
            text.text = currentHealth.ToString() ;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (currentHealth <= 0)
        {
            Die();
        }
	}

    public void Die()
    {
        if (text)
        {
            text.text = currentHealth.ToString();
        }
    }

    public void TakeDamage(Damage source, float addDamage)
    {
        currentHealth -= source.attackPower + addDamage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        text.text = currentHealth.ToString();
    }
}
