using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;
    [SerializeField] private GameObject bounceEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулись ли с объектом, у которого есть физический материал с отскоком
        if (collision.collider.sharedMaterial != null && collision.collider.sharedMaterial.bounciness > 0)
        {
            // Рассчитываем направление отскока
            Vector3 bounceDirection = collision.contacts[0].normal;

            // Добавляем силу отскока к Rigidbody персонажа
            GetComponent<Rigidbody>().AddForce(-bounceDirection * bounceForce, ForceMode.Impulse);

            // Создаем эффект частиц
            Instantiate(bounceEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
