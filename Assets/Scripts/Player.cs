using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject PlayerArm;
    
    public Transform firePoint;
    private Camera cam;
    public float bulletSpeed = 20f;
    public int maxAttempts = 10;
    public int currentAttempts = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        RotateArmTowardsMouse();
        if (Input.GetMouseButtonDown(0) && currentAttempts < maxAttempts)
        {
            Shoot();
        }

    }

    void RotateArmTowardsMouse()
    {
        /*Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.z));
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        PlayerArm.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));*/

        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 9.5f));
        PlayerArm.transform.LookAt(mousePos);



    }
    void Shoot()
    {
        currentAttempts++;
        GameObject GObullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = GObullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }

}
