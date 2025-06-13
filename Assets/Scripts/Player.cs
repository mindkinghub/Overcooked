using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private GameInput gameInput;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
    private void HandleMovement()
    {
        // 处理移动逻辑
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;

        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);

        }
    }
    private void HandleInteraction()
    {
        // 处理交互逻辑
        RaycastHit hitinfo;
        bool isCollider = Physics.Raycast(transform.position, transform.forward, out hitinfo, 2f);
        if (isCollider)
        {
            hitinfo.transform.GetComponent<ClearCounter>().Interact();
            print(hitinfo.collider.gameObject);
        }

    }
}
