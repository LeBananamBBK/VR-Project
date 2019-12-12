using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class ShootWhenGrabbed : MonoBehaviour {

    public OVRInput.Button shootButton;
    private OVRGrabbable ovrGrabbable;
    private SimpleShoot simpleShoot;

	// Use this for initialization
	void Start () {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();


	}
	
	// Update is called once per frame
	void Update () {
		if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootButton, ovrGrabbable.grabbedBy.getController()))
        {
            //Shoot
            simpleShoot.TriggerShoot();
        }
	}
}
