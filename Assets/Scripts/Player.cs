using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 10;

<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
=======
    private bool isWalking = false;     // 人物是否在行走
    private BaseCounter seletedCounter;

    private void Awake()
>>>>>>> Stashed changes
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
        

<<<<<<< Updated upstream
=======
        }
    }
    private void HandleInteraction()
    {
        // 处理交互逻辑
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))
        {
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }


    }
    public void SetSelectedCounter(BaseCounter counter)
    {
        if(counter != seletedCounter)
        {
            seletedCounter?.CancelSelect();
            counter?.SelectCounter();
        }
        this.seletedCounter = counter;
>>>>>>> Stashed changes
    }
}
