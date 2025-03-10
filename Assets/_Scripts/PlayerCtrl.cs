using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    private Rigidbody rb;
    private float pressVertical;
    private float pressHorizontal;
    [SerializeField] float speedPlayer = 6f;
    [SerializeField] float speedPlayerRotate = 4f;
    [SerializeField] float jumpPower = 19f;
    [SerializeField] float gravity = -40f;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject playerCamera;
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] LayerMask groundLayer;

    Vector3 offsetRaycast = new Vector3(0, 0.2f, 0);
    [SerializeField] float lengRaycast = 0.3f;

    public bool maybeJump;
    bool inGround;
    bool isDead;
    bool isComplete;
    public bool isReset;
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        Physics.gravity = new Vector3(0, gravity, 0);
        transform.position = Vector3.zero;

    }
    private void Update()
    {
        if (isDead) return;
        if (isComplete) return;
        CheckDead();
        CheckInput();
        CheckGround();
        PlayerMove();
        JumpOnPC();
    }
    void CheckDead()
    {
        if (transform.position.y < -0.5f)
        {
            playerAnimation.AnimDead();
            Invoke("ShowFinishPanel", 2f);
            GameManager.Instance.iq--;
            isDead = true;
            return;
        }
    }
    void CheckInput()
    {
        if (GameManager.Instance.playOnMobile)
        {
            JoystickMoveInput();
        }
        else
        {
            PcMoveInput();
        }
    }
    void PcMoveInput()
    {
        this.pressVertical = Input.GetAxis("Vertical");
        this.pressHorizontal = Input.GetAxis("Horizontal");        
    }
        void JoystickMoveInput()
    {
        this.pressVertical = Joystick.instance.Vertical();
        this.pressHorizontal = Joystick.instance.Horizontal();
    }
    void CheckGround()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + offsetRaycast, Vector3.down, out hit, lengRaycast, groundLayer);

        if (hit.collider)
        {
            inGround = true;
        }
        else
        {
            playerAnimation.AnimJump(false);
            inGround = false;
        }
        playerAnimation.SetStateInGround(inGround);
    }
    void JumpOnPC()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inGround)
        {
            playerAnimation.AnimJump(true);
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        }
    }
    public void JumpOnMoblie()
    {
        if (inGround)
        {
            playerAnimation.AnimJump(true);
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        }
    }
    void PlayerMove()
    {
        isReset = false;
        Vector3 movement1 = Vector3.forward * pressVertical;
        Vector3 movement2 = Vector3.right * pressHorizontal;
        moveDirection = movement1 + movement2;
        moveDirection.y = 0;
        rb.MovePosition(rb.position + this.speedPlayer * moveDirection * Time.deltaTime);
        if (moveDirection != Vector3.zero)
        {
            playerAnimation.AnimRun();
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedPlayerRotate);
        }
        else
        {
            playerAnimation.AnimIdle();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Target")
        {
            isComplete = true;
            transform.DORotate(other.transform.forward, 0.5f)
                .SetUpdate(UpdateType.Normal, true)
                .OnComplete(() =>
                {
                    UIManager.Instance.AnimLoading1();
                    transform.DOMove(other.transform.position + 2 * other.transform.forward, 1f)
                        .SetUpdate(UpdateType.Normal, true)
                        .OnComplete(GameManager.Instance.NextLevel);
                });
        }
    }
    void ShowFinishPanel()
    {
        GameManager.Instance.ShowPanelFinish();
    }    
    public void ResetPlayer()
    {
        isDead = false;
        isComplete = false;
        transform.position = Vector3.zero;
        isReset = true;
    }
    public void ResetAnimPlayer()
    {
        playerAnimation.ExitAnim();
    }
} 
