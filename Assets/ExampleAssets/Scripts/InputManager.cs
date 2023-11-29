using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject arObj;
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager arRaycastManager;
    
    List<ARRaycastHit> arHits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (arRaycastManager.Raycast(ray, arHits))
            {
                Pose pose = arHits[0].pose;
                Instantiate(arObj, pose.position, pose.rotation);
            }
            
        }
    }
}
