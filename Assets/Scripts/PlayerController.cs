using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Rigidbody rb;
    private int count;
    public GameObject WinTextObject;

    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();

        if (count >= 12)
        {
            WinTextObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

}
