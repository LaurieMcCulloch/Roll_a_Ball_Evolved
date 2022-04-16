using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Rigidbody rb;    
    public GameObject WinTextObject;

    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;

    void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                       
    }


    private void GameManagerOnGameStateChanged(GameState state)
    {
        // Set Pickup counter at start of level
        if(state == GameState.PlayLevel)
        {
            SetCountText();
            rb.isKinematic = false; // Ball only rolls around during gameplay
        }
        else
        {
            rb.isKinematic = true;
        }
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
        //https://www.youtube.com/watch?v=y7WgV8-yfcI&t=136s
    }
    void SetCountText()
    {
        if (GameManager.Instance.State == GameState.PlayLevel)
        {
            countText.text = LevelManager.Instance.CurrentLevel.PickupsRemaining.ToString();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.State == GameState.PlayLevel)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);           
            
            LevelManager.Instance.OnPickupCollision(other.gameObject);
            SetCountText();
        }
    }

}
