using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotateSpeed = 500;
    [SerializeField] private DynamicJoystick dynamicJoystick;

    private Quaternion targetRotation;
    private Animator animator;
    private Rigidbody rigidbody;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = gameObject.GetComponentInChildren<Animator>();
        if(cameraController == null)
            cameraController = Camera.main.GetComponent<CameraController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Desktop Version
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");


        //Mobile Version
        float h = dynamicJoystick.Horizontal;
        float v = dynamicJoystick.Vertical;

        float moveAmount = Mathf.Clamp(Mathf.Abs(h)+ Mathf.Abs(v), 0, 1);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Calllllllllllllllll");
            rigidbody.AddForce(new Vector3(0, 600, 0));

        }

        var moveInput = (new Vector3(h, 0, v)).normalized;
        var moveDirection = cameraController.GetDirection * moveInput;

        if(moveAmount > 0)
        {
            transform.position += moveDirection * Time.deltaTime * speed;
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        animator.SetFloat("Blend", moveAmount);
    }

    public static int score = 0;
    private void OnCollisionEnter(Collision other) {
        if(other != null)
        {
            if(other.gameObject.tag == "Item")
            {
                CubeItem cubeItem = other.gameObject.GetComponent<CubeItem>();
                score += cubeItem.score;
                Destroy(other.gameObject);
                Debug.Log("########### score => " + score);
            }
            else if (other.gameObject.tag =="Enemy")
            {
                Debug.Log("########### YOU LOSE!");
                DialogController dialogController = FindObjectOfType<DialogController>();
                if(dialogController != null)
                {
                    dialogController.ShowLost(true);
                }
            }
        }
    }
}
