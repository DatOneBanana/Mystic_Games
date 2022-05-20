using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    // detection pt
    [Header("Detection Parameters")]
    public Transform detectionpt;
    
    //detection radius
    private const float detectionradius = 0.04f;

    //detection layer
    public LayerMask detectionlayer;

    public GameObject detectedObject;
    [Header("Others")]

    //list of picked items
    public List<GameObject> pickedItems = new List<GameObject>();

    // void Start()
    // {
    //     detectedObject=Resources.Load("icon") as GameObject;
    // }


    void Update()
    {
      
        if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<icon>()?.Interact();
                                Debug.Log("interact");

            }
        }
    }

    // Update is called once per frame
    bool InteractInput(){
        return Input.GetKeyDown(KeyCode.E);
    }
//detect obj or not
    bool DetectObject(){
        Collider2D obj = Physics2D.OverlapCircle(detectionpt.position,detectionradius,detectionlayer);
       if(obj==null)
       {
           detectedObject=null;
           return false;
       }
       else
       {
           detectedObject = obj.gameObject;
           return true;

       }
    //return isDetected;
    }

    public void PickUpItem(GameObject icon)
    {
        pickedItems.Add(icon);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionpt.position,detectionradius);
    }
}
