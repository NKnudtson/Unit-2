using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public GameObject projectilePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input
        horizontalInput = Input.GetAxis("Horizontal");

        //Move Player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //If player is at bounds, lock me into x -10/10 based on which side player is on
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Press space to launch projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            Debug.Log("I have pressed space");
        }

    }
}
