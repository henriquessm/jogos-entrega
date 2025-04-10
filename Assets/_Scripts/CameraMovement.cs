using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;          // Jogador a ser seguido
    public float smoothSpeed = 0.125f; // Suavidade do movimento

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
