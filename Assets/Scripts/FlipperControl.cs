using UnityEngine;

public class FlipperControl : MonoBehaviour
{
    public KeyCode controlKey = KeyCode.LeftArrow;  // ������� ��� ���������� ���������
    public float force = 1000f;  // ����, � ������� ������� ����� ���������
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
            motor.targetVelocity = force;  // ����������� ��������
        }
        else
        {
            motor.targetVelocity = -force;  // ����������� � �������� ���������
        }
        hinge.motor = motor;
    }
}
