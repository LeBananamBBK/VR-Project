using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that allows players to charge up their melee weapons using a button, and upon release, would deal higher critical damage.
public class ChargeSS : MonoBehaviour {
    
    //Get input button
    public OVRInput.Button inputButton;
    //Get meshrenderer of the melee weapon
    //private MeshRenderer meshRenderer;
    //Get OVRGrabbable
    private OVRGrabbable ovrGrabbable;

    private float currentcharge = 0f;
    private bool initiated = false;

	// Use this for initialization
	void Start () {
        //meshRenderer = GetComponent<MeshRenderer>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ovrGrabbable.isGrabbed)
        {
            if (OVRInput.GetDown(inputButton, ovrGrabbable.grabbedBy.getController()))
            {
                initiated = true;
                currentcharge += Time.deltaTime;
                transform.localScale = (Vector3.one + new Vector3(currentcharge,currentcharge,currentcharge));
            }
            else
            {
                if (initiated)
                {
                    initiated = false;
                    TriggerUse();
                }
            }
        }
    }

    //Trigger the use
    public void TriggerUse()
    {
        currentcharge = 0f;
        transform.localScale = Vector3.one;
    }
}
