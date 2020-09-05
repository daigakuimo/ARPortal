using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARCameraController : MonoBehaviour
{
    public Camera mainCam;

    // Update is called once per frame
    void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Portal")) {
			// Use xor operator to toggle the ARWorld layer in the mainCam's culling mask.
			mainCam.cullingMask ^= 1 << LayerMask.NameToLayer("ARWorld");
		}
	}

}
