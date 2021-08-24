using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject towerprefabs;

    [SerializeField] bool isPlaceble = false;
    public bool IsPlaceble{get {return isPlaceble;}}
    
    private void OnMouseDown() {
        if(isPlaceble){
           Instantiate(towerprefabs,transform.position,Quaternion.identity);
            isPlaceble = false;
        }
    
    }
}
