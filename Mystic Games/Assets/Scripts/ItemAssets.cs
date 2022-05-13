using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    // Start is called before the first frame update
    public static ItemAssets Instance {get; private set;} 

    private void Awake(){
        Instance = this;
    }
    public Transform pfItemWorld;
    public Sprite swordSprite;
    public Sprite potionSprite;
    public Sprite coinSprite;

    public Sprite medkitSprite;
    

}
