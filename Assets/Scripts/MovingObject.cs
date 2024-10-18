using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 3f;  // Скорость движения
    public float distance = 5f;  // Дистанция, на которую объект двигается
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  // Запоминаем стартовую позицию объекта
    }

    void Update()
    {
        // Двигаем объект вперед-назад на определенное расстояние
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(movement, 0, 0);
    }
}
