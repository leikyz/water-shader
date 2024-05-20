using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement de la caméra
    public float lookSpeed = 2f; // Vitesse de rotation de la caméra

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        // Verrouille le curseur au centre de l'écran et le rend invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Récupère les entrées de déplacement
        float moveForward = Input.GetKey(KeyCode.Z) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);
        float moveRight = Input.GetKey(KeyCode.Q) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);

        // Calcule le vecteur de déplacement
        Vector3 moveDirection = transform.forward * moveForward + transform.right * moveRight;
        moveDirection.Normalize();

        // Applique le déplacement à la caméra
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Récupère les entrées de rotation (souris)
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Applique la rotation de la caméra
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Applique les rotations en utilisant les quaternions
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.localRotation = rotation;
    }
}
