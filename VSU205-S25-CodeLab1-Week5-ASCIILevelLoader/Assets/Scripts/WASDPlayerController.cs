using UnityEngine;

public class WASDPlayerController : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyLeft;
    public KeyCode keyDown;
    public KeyCode keyRight;
    public float speed = 1;
    
    public Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyUp))
        {
            rb.AddForce(Vector3.up * speed);
        }

        if (Input.GetKeyDown(keyLeft))
        {
            rb.AddForce(Vector3.left * speed);
        }

        if (Input.GetKeyDown(keyDown))
        {
            rb.AddForce(Vector3.down * speed);
        }

        if (Input.GetKeyDown(keyRight))
        {
            rb.AddForce(Vector3.right * speed);
        }
        
    }
    
    
    
    
    
}
