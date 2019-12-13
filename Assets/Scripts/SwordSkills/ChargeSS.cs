using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A class that allows players to charge up their melee weapons using a button, and upon release, would deal higher critical damage.
public class ChargeSS : MonoBehaviour {
    
    //Get input button
    public OVRInput.Button inputButton;
    //Get meshrenderer of the melee weapon
    //private MeshRenderer meshRenderer;
    //Get OVRGrabbable
    private OVRGrabbable ovrGrabbable;
    //Max charge time
    public float maxTime = 3f;

    private float currentcharge = 0f;
    private bool initiated = false;
    private Vector3 initransform;
    

    //Debug
    private TextMesh text;

	// Use this for initialization
	void Start () {
        //meshRenderer = GetComponent<MeshRenderer>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        initransform = transform.localScale;

        text = GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (ovrGrabbable.isGrabbed)
        {
            if (OVRInput.Get(inputButton, ovrGrabbable.grabbedBy.getController()))
            {
                initiated = true;

                if (currentcharge < maxTime)
                {
                    currentcharge += Time.deltaTime;
                }
                else
                {
                    currentcharge = maxTime;
                }

                transform.localScale = initransform + new Vector3(currentcharge,currentcharge,currentcharge);
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

        //Debug
        if (text)
        {
            text.text = gameObject.layer.ToString();
        }
        
    }

    //Trigger the use
    public void TriggerUse()
    {
        currentcharge = 0f;
        transform.localScale = initransform;
    }
}
