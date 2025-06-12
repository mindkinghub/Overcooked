using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = direction.normalized;   

        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero) {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
            //transform.forward = direction;
        }  
        

    }
}
