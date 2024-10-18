using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bounceForce = 1000f;  // Сила отталкивания

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что столкновение произошло с объектом, у которого есть Rigidbody (например, шарик)
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // Рассчитываем направление отталкивания как направление от капсулы к шарику
            Vector3 bounceDirection = collision.transform.position - transform.position;
            bounceDirection = bounceDirection.normalized;  // Нормализуем вектор, чтобы получить направление

            // Применяем силу отталкивания к шарику
            ballRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
