using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Скорость вращения

    void Update()
    {
        // Вращаем объект вокруг оси Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
