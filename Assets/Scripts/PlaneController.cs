using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    [SerializeField, Tooltip("AR空間にポータルを表示")] GameObject portal;

    [SerializeField, Tooltip("ARWorld")] GameObject ARWorld;

    public Camera mainCam;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.Planes))
            {
                // Raycastの衝突情報は距離によってソートされるため、0番目が最も近い場所でヒットした情報となります
                var hitPose = hits[0].pose;

                if (!spawnedObject)
                {
                    spawnedObject = Instantiate(portal, hitPose.position, Quaternion.identity);
                    spawnedObject.transform.localScale = new Vector3(spawnedObject.transform.localScale.x / 2, spawnedObject.transform.localScale.y / 2 , spawnedObject.transform.localScale.z / 2);
                    spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y + (spawnedObject.transform.localScale.y / 2), spawnedObject.transform.position.z);
                    // spawnedObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                    
                    // ARWorld.transform.position = new Vector3(ARWorld.transform.position.x,hitPose.position.y, ARWorld.transform.position.z);
                }
            }
        }
    }
}
