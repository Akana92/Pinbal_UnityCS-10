using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.LeftArrow;  // Клавиша для управления флиппером
    public float force = 1000f;  // Сила, с которой флиппер будет двигаться
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        JointMotor motor = hinge.motor;
        if (Input.GetKey(controlKey))
        {
            motor.targetVelocity = force;  // Направление вращения
        }
        else
        {
            motor.targetVelocity = -force;  // Возвращение в исходное положение
        }
        hinge.motor = motor;
    }
}
