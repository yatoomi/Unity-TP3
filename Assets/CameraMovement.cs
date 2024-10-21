using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
   
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] private float zoomSpeed = 2f; // Vitesse de zoom
    [SerializeField] private float minZoom = 1f;   // Distance minimale de zoom
    [SerializeField] private float maxZoom = 20f;  // Distance maximale de zoom

    private Vector3 previousPosition;

    private void Update()
    {
        // Rotation de la caméra avec le clic gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // Mouvement horizontal
            float rotationAroundXAxis = direction.y * 180;  // Mouvement vertical

            cam.transform.position = PlanetManager.current.Target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }

        // Zoom avec la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distanceToTarget -= scroll * zoomSpeed; // Modifie la distance cible en fonction du défilement
        distanceToTarget = Mathf.Clamp(distanceToTarget, minZoom, maxZoom); // Limite le zoom entre min et max

        // Applique le zoom en ajustant la position de la caméra
        cam.transform.position = PlanetManager.current.Target.position - cam.transform.forward * distanceToTarget;
    }
}
