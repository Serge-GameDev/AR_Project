using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;
    [SerializeField] private GameObject bounceEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ����������� �� � ��������, � �������� ���� ���������� �������� � ��������
        if (collision.collider.sharedMaterial != null && collision.collider.sharedMaterial.bounciness > 0)
        {
            // ������������ ����������� �������
            Vector3 bounceDirection = collision.contacts[0].normal;

            // ��������� ���� ������� � Rigidbody ���������
            GetComponent<Rigidbody>().AddForce(-bounceDirection * bounceForce, ForceMode.Impulse);

            // ������� ������ ������
            Instantiate(bounceEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
