using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{

    public Camera cam;
    public Rigidbody2D Rigidbody2D;
    private float MaxWidth;
    public Renderer renderer;
    

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        {
            Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
            Vector3 targetwidth = cam.ScreenToWorldPoint(upperCorner);
            renderer = GetComponent<Renderer>();
            float hoopWidth = renderer.bounds.extents.x;
            Rigidbody2D = GetComponent<Rigidbody2D>();
               
            MaxWidth = targetwidth.x - hoopWidth;


        }
    }

    // Update is called once per physics timeset
    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, this.transform.position.y, 0.0f);
        float targetwidth = Mathf.Clamp(targetPosition.x, -MaxWidth, MaxWidth);
        targetPosition = new Vector3(targetwidth, targetPosition.y, targetPosition.z);
        Rigidbody2D.MovePosition(targetPosition);

    }
}

