using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float restRotation = 45.0f;
    public float pressedRotation = -20.0f;
    public float speed = 100f; 

    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, restRotation, 0f));

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Boing");
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(new Vector3(0f, restRotation, 0f)));
        }
        else
        {
           // transform.rotation = Quaternion.Euler(new Vector3(0f, pressedRotation, 0f));
        }
    }
    /*
    public float restPosition = -55f;
    public float pressedPosition = 55f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;

    HingeJoint hingeJoint;
    public string inputName;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = hitStrength;
        jointSpring.damper = flipperDamper;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)        
        {
            Debug.Log("Boing");
            jointSpring.targetPosition = pressedPosition; 
        }
        else
        {
            jointSpring.targetPosition = restPosition; 
        }
        hingeJoint.spring = jointSpring;
        hingeJoint.useLimits = true;

    }*/

}
