using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float Sensivity = 2;
    [SerializeField] float jumpForce = 10;
    [SerializeField] Camera cam;
    private Rigidbody rb;

    bool isGrounded;
    bool Pressed;
    float currentSpeed;
    Vector3 angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = movementSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        angle += Vector3.right * -Input.GetAxis("Mouse Y") * Sensivity;
        angle.x = Mathf.Clamp(angle.x, -70, 70);

        movementSpeed = Input.GetKey(KeyCode.LeftShift) ? currentSpeed * 2 : currentSpeed;

        transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Pressed = true;
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * Sensivity, 0);
        cam.transform.localEulerAngles = angle;
        
    }
    private void FixedUpdate()
    {
        if (Pressed)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Pressed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
