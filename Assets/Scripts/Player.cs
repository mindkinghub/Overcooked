using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 100;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;  // 让人物只与Counter层物体发生碰撞

    private bool isWalking = false;     // 人物是否在行走
    private ClearCounter seletedCounter;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
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

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        seletedCounter?.Interact(this);
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
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))
        {
            if(hitinfo.transform.TryGetComponent<ClearCounter>(out ClearCounter counter))
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
    public void SetSelectedCounter(ClearCounter counter)
    {
        if(counter != seletedCounter)
        {
            seletedCounter?.CancelSelect();
            counter?.SelectCounter();
        }
        this.seletedCounter = counter;
    }
}
