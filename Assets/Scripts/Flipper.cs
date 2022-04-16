using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
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

    }
}
