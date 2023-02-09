using System.Collections;
using UnityEngine;

public class MoveUpPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopTime;
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
    }

    private void Start()
    {
        StartCoroutine(PlatformMovement());
    }
   
    private IEnumerator PlatformMovement()
    {
        while (true)
        {
            motor.motorSpeed = -speed;
            sliderJoint.motor = motor;
            yield return new WaitForSeconds(stopTime);
            motor.motorSpeed = speed;
            sliderJoint.motor = motor;
            yield return new WaitForSeconds(stopTime);
        }
    }
}
