using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    internal GameObject shootedObject;
    private bool isGameCompleted;

    //Rotate the Card
    private bool isRotating;
    private Vector3 mousePressDownPos;
    private Vector3 _mouseOffSet;
    private Vector3 _rotation;
    internal float _sensivity;
    // ***************************


    //Trajectory
    private Vector3 lateralVector; // Yan olarak, enlemesine
    private Vector3 direction;
    GameObject pointPrefab;
    GameObject [] pointPrefabs;
    int numberOfPoints = 100;
    private float force = 10;
    private bool isObjectShooted;
    public int hitIndex;
    private Vector3 directionRelection;
    public Transform hitObject;


    Animator animator;
    void Start()
    {
        

        lateralVector = transform.forward * 100;
        
        shootedObject = GetComponentInChildren<ShootedObjectController>().gameObject;

        pointPrefab = Resources.Load<GameObject>("Prefabs/PointPrefab");

        rb = shootedObject.GetComponent<Rigidbody>();
        
        _sensivity = 0.1f;
        
        _rotation = Vector3.zero;

        pointPrefabs = new GameObject [numberOfPoints];
        
        hitIndex = numberOfPoints - 1;

        for(int i = 0; i < numberOfPoints; i++)
        {
            pointPrefabs[i] = Instantiate(pointPrefab, shootedObject.transform.position, Quaternion.identity);
            //pointPrefabs[i].GetComponents<PointPrefabController>().index = i;
        }
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        if(PlayerManager.isGameStarted)
        {
            if(Input.GetMouseButtonDown(0) && !isRotating)
            {
                isRotating = true;
                mousePressDownPos = Input.mousePosition;
            }
                else if(Input.GetMouseButton(0) && isRotating)
            {
                RotateObject();
                CheckLevel3Reflection();
            }
            else if (Input.GetMouseButtonUp(0) && isRotating)
            {
                isRotating = false;
                Shoot();
            }
    
        }

        
    }
    private void CheckLevel3Reflection()
    {
        if (hitObject != null) 
        {
            hitIndex = hitObject.GetComponent<PointPrefabController>().index + 1;
        }
        else 
        {
            hitIndex = numberOfPoints;
        }
        for(int i = 0; i < hitIndex; i++)
        {
            pointPrefabs[i].transform.position = PointPosition(i * .01f);
        }
        
        for(int i = hitIndex; i < numberOfPoints; i++)
        {
            pointPrefabs[i].transform.position = PointReflectionPosition((hitIndex - i) * .01f, hitObject);
        }


    }

    private void RotateObject()
    {
        _mouseOffSet = (Input.mousePosition - mousePressDownPos);
        _rotation.y = (_mouseOffSet.x) * _sensivity;

        transform.eulerAngles += _rotation;

        mousePressDownPos = Input.mousePosition;
        direction = transform.forward;

    }

    void Shoot()
    {
        foreach(var ball in pointPrefabs)
        {
            ball.SetActive(false);
        }

        shootedObject.transform.SetParent(null);
        StartCoroutine(ThrowAnim());

        _sensivity /= 7;

        List<Vector3> points = new List<Vector3>();

        points.Add(transform.position);

        foreach(var point in pointPrefabs)
        {
            points.Add(point.transform.position);
        }
        
        Vector3 [] pathPlayer = points.ToArray();
        
        iTween.MoveTo(shootedObject, iTween.Hash("path", pathPlayer, "orienttopath", false, "easetype", iTween.EaseType.linear, "speed", 150f, "looptype", iTween.LoopType.none, "delay", 0, "onupdate", "CheckUpdate", "onupdatetarget", gameObject, "oncomplete", "CheckComplete", "oncompletetarget", gameObject));

        isObjectShooted = true;

        // ? 
        shootedObject.GetComponentInChildren<TrailRenderer>().enabled = true;
        shootedObject.GetComponentInChildren<Animator>().enabled = true;
        
    }
    Vector3 PointPosition (float t)
    {
        Vector3 currentPointPosition = shootedObject.transform.position + (direction.normalized * force * t) + 2f * lateralVector * (t * t * t * t * t);
        return currentPointPosition;
    }
    Vector3 PointReflectionPosition (float t, Transform hitPoint)
    {
        Vector3 currentPointPosition = hitPoint.position + (directionRelection.normalized * force * t) + 2f * lateralVector * (t * t * t * t * t);

        return currentPointPosition;
    }

    private IEnumerator ThrowAnim()
    {
        animator.SetBool("isThrowing", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isThrowing", false);
    }
}