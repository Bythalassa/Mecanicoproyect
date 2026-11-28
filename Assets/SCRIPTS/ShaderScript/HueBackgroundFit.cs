using UnityEngine;

/// <summary>
/// Mantiene un Quad con el material HueBackground cubriendo toda la camara
/// y lo dibuja detras de todo. Ponlo en un Quad (GameObject > 3D Object > Quad).
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(MeshRenderer))]
public class HueBackgroundFit : MonoBehaviour
{
    public Camera cam;
    [Tooltip("Margen extra para que no se vean bordes")]
    public float margin = 1.1f;
    [Tooltip("Z del fondo (debe estar detras del nivel)")]
    public float depthZ = 10f;
    public string sortingLayer = "Default";
    public int sortingOrder = -1000;

    MeshRenderer rend;

    void OnEnable() => rend = GetComponent<MeshRenderer>();

    void LateUpdate()
    {
        if (cam == null) cam = Camera.main;
        if (cam == null) return;

        Transform c = cam.transform;
        transform.position = new Vector3(c.position.x, c.position.y, depthZ);
        transform.rotation = Quaternion.identity;

        float height;
        if (cam.orthographic)
            height = cam.orthographicSize * 2f;
        else
            height = 2f * Mathf.Abs(depthZ - c.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);

        float width = height * cam.aspect;
        transform.localScale = new Vector3(width * margin, height * margin, 1f);

        if (rend != null)
        {
            rend.sortingLayerName = sortingLayer;
            rend.sortingOrder = sortingOrder;
        }
    }
}
