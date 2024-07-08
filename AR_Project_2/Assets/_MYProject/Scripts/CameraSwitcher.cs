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
            // Переключаем на камеру игрока
            arCamera.Priority = 0;
            playerCamera.Priority = 10;
        }
        else
        {
            // Переключаем на AR камеру
            arCamera.Priority = 10;
            playerCamera.Priority = 0;
        }

        // Инвертируем флаг для следующего нажатия
        isARCameraActive = !isARCameraActive;
    }
}
