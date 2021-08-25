using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerprefabs;

    [SerializeField] bool isPlaceble = false;
    public bool IsPlaceble{get {return isPlaceble;}}
    
    private void OnMouseDown() {
        if(isPlaceble){
            bool isPlaced = towerprefabs.CreateTower(towerprefabs,transform.position);
            // Instantiate(towerprefabs,transform.position,Quaternion.identity);
            isPlaceble = !isPlaced;
        }
    
    }
}
