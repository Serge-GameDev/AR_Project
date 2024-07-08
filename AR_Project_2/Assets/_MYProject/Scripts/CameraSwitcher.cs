using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera arCamera;
    public CinemachineFreeLook playerCamera;

    private bool isARCameraActive = true;

    void Start()
    {
        SwitchCamera();
    }

    public void SwitchCamera()
    {
        if (isARCameraActive)
        {
            // ����������� �� ������ ������
            arCamera.Priority = 0;
            playerCamera.Priority = 10;
        }
        else
        {
            // ����������� �� AR ������
            arCamera.Priority = 10;
            playerCamera.Priority = 0;
        }

        // ����������� ���� ��� ���������� �������
        isARCameraActive = !isARCameraActive;
    }
}
