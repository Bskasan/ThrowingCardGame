using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPrefabController : MonoBehaviour
{
    internal int index;
    public bool hitReflector;
    PlayerController player;

    private void Start() 
    {
        player = FindObjectOfType<PlayerController>();
    }

    /*private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Reflector"))    
        {
            // GameObject [] pointPrefabs = GameObject.FindGameObjectsWithTag("Point");

            // if(pointPrefabs.Where(x => x.GetComponent<PointPrefabController>().hitReflector).FirstOrDefault() != null)
            // {
            //     pointPrefabs.Where(x => x.GetComponent<PointPrefabController>().hitReflector).First().GetComponent<PointPrefabController>().hitReflector = false;
            // }

            hitReflector = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Reflector"))    
        {
            hitReflector = false;
        }

    }*/
}
