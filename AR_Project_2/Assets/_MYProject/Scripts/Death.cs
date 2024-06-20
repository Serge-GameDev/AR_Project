
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private UiController uiControllerScript;
    private void Start()
    {
        uiControllerScript = FindObjectOfType<UiController>();
    }
    public void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Entered to death zone");
            uiControllerScript.OpenEndScreen();


        }
    }
}
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private UiController uiControllerScript;

    private void Start()
    {
        // ����� ������ � ����������� UiController
        uiControllerScript = FindObjectOfType<UiController>();

        // ���������, ��� ��������� ������� ������
        if (uiControllerScript == null)
        {
            Debug.LogError("UiController component not found in the scene.");
        }
        else
        {
            Debug.Log("UiController component found successfully.");
        }

        // �������� ������� ���������� Collider
        if (GetComponent<Collider>() == null)
        {
            Debug.LogError("Collider not found on the GameObject.");
        }
        else
        {
            Debug.Log("Collider found on the GameObject.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in the Chest attack area");

            // ���������, ��� ��������� ������� ������, ������ ��� ������� �����
            if (uiControllerScript != null)
            {
                uiControllerScript.OpenEndScreen();
            }

            // ������ ������ ������ (��������, ���������� ������ ������)
           // Destroy(collision.gameObject);
        }
    }
}
