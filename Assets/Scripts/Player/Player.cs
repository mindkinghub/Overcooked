using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;  // 让人物只与Counter层物体发生碰撞
    [SerializeField] private bool isPlayer1 = true; // 区分玩家1（默认WASD）和玩家2（默认方向键）

    private bool isWalking = false;     // 人物是否在行走
    private BaseCounter seletedCounter;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameInput.SetPlayer(isPlayer1);
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnOperateAction += GameInput_OnOperateAction;
        gameInput.OnInteractAction2 += GameInput_OnInteractAction2;
        gameInput.OnOperateAction2 += GameInput_OnOperateAction2;
    }

    void Update()
    {
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        GetComponent<Rigidbody>().velocity = Vector3.zero;  // 避免碰撞后弹飞人物
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (isPlayer1) seletedCounter?.Interact(this);
    }

    private void GameInput_OnOperateAction(object sender, System.EventArgs e)
    {
        if (isPlayer1) seletedCounter?.InteractOperate(this);
    }
    private void GameInput_OnInteractAction2(object sender, System.EventArgs e)
    {
        if (!isPlayer1) seletedCounter?.Interact(this);
    }

    private void GameInput_OnOperateAction2(object sender, System.EventArgs e)
    {
        if (!isPlayer1) seletedCounter?.InteractOperate(this);
    }

    private void HandleMovement()
    {
        // 处理移动逻辑
        Vector3 direction = gameInput.GetMovementDirectionNormalized();

        isWalking = (direction != Vector3.zero);

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
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
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
        if (counter != seletedCounter)
        {
            seletedCounter?.CancelSelect();
            counter?.SelectCounter();
            this.seletedCounter = counter;
        }

    }
}
