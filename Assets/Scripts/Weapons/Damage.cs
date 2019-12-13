using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float attackPower = 5;
    public LayerMask targetLayer;

    private Collider _collider;
    private ChargeSS skill;

    // Use this for initialization
    void Start ()
    {
        _collider = GetComponentInChildren<Collider>();
        skill = gameObject.GetComponent<ChargeSS>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		
	}

    public virtual void OnTriggerEnter(Collider collider)
    {
        Collide(collider.gameObject);
    }

    public virtual void Collide(GameObject collider)
    {
        if (!(0 != (targetLayer & (1 << collider.layer))))
        {
            return;
        }
        else
        {
            ResetSkills();

            Health targetHealth = collider.GetComponent<Health>();

            if (targetHealth)
            {
                float addDamage = skill.getCurrentCharge() * 5f;
                targetHealth.TakeDamage(this, addDamage);
            }
        }
    }

    public virtual void ResetSkills()
    {
        skill.Reset();
    }
}
