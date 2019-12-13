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
    public float maxChargeTime = 3f;
    //CD
    public float CD = 5f;

    private float temptimer = 0f;
    private bool onCD = false;

    private float currentcharge = 0f;
    private bool initiated = false;
    private Vector3 initransform;
    

    //Debug
    private TextMesh text;

    public float getCurrentCharge()
    {
        return currentcharge;
    }
    

	// Use this for initialization
	void Start () {
        //meshRenderer = GetComponent<MeshRenderer>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        initransform = transform.localScale;

        text = GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Cooldown hanlding
        if (onCD)
        {
            temptimer -= Time.deltaTime;

            if (temptimer <= 0)
            {
                temptimer = 0f;
                onCD = false;
            }
        }

        if (ovrGrabbable.isGrabbed)
        {
            if (OVRInput.Get(inputButton, ovrGrabbable.grabbedBy.getController()) && !onCD)
            {
                initiated = true;

                if (currentcharge < maxChargeTime)
                {
                    currentcharge += Time.deltaTime;
                }
                else
                {
                    currentcharge = maxChargeTime;
                }

                transform.localScale = initransform + new Vector3(currentcharge,currentcharge,currentcharge);
            }
            else
            {
                if (initiated)
                {
                    initiated = false;
                    TriggerUse();
                    CDReset();
                }
            }
        }

        //Debug
        if (text)
        {
            text.text = temptimer.ToString();
        }
        
    }

    //Trigger the use
    public void TriggerUse()
    {
        currentcharge = 0f;
        transform.localScale = initransform;
    }

    public void CDReset()
    {
        temptimer = CD;
        onCD = true;
    }

    public virtual void Reset()
    {
        TriggerUse();
        CDReset();
    }
}
