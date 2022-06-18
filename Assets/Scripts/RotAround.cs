using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAround : MonoBehaviour
{
    public float rotSpeed; //speed of rotation
    public float moveSpeed = 80;
    public GameObject rotPivot;
    public float move_dir = -1;


    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject circle;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotPivot.transform.position, new Vector3(0, 0, 1), rotSpeed * Time.deltaTime); //rotate smaller circle around bigger one
        
    }

//spawn small circles
public void Spawn()
    {
        moveSpeed = rotSpeed;
        GameObject newCircle = Instantiate(circle, spawner.transform.position, spawner.transform.rotation);
        newCircle.transform.Translate(0, -1, 0);
    }

}

