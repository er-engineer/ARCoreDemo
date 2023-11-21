using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    // Nesne tanımlamaları
    [SerializeField] private GameObject arGameObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARRaycastManager arraycastManager;
    //Kameradan gelen hitting verilerini tutmak için oluşturulan liste
    List<ARRaycastHit> arHits = new List<ARRaycastHit>();

    //  
    void Start()
    {
        
    }

    // Her frame geçişinde yapılacak olanlar
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ //Ekrana dokunulunca yapılacak olanlar
            //Dokunulunca gönderilen noktanın Ray nesnesine atanması işlemi
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            //Bu Ray nesnelerinin hitting konumlarıyla eşlenmesi
            if(arraycastManager.Raycast(ray, arHits)){
                Pose pose = arHits[0].pose;
                //Nesnenin hitting konumuna ilgili rotasyon ile yerleştirilmesi
                Instantiate(arGameObject, pose.position, pose.rotation);
            }
        }
    }
}