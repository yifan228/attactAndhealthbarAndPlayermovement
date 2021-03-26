using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooPooshoot : MonoBehaviour
{
    public GameObject Poo;
    public float launchForce;
    public Transform shootPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shootPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = pointPosition(i * spaceBetweenPoints);
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        

    }
    public void shoot()
    {
        GameObject newPoo = Instantiate(Poo, shootPoint.position, shootPoint.rotation);
        newPoo.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
    public Vector2 pointPosition(float t)
    {
        Vector2 position = (Vector2)shootPoint.position + direction.normalized * launchForce * t + 0.5f * Physics2D.gravity * t * t;
        
        return position;
        
    }
    

}
