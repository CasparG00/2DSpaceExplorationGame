using UnityEngine;

public class CastShadow : MonoBehaviour
{
    [SerializeField] private Transform shadow;
    [SerializeField] private Transform lightSource;

    private void LateUpdate()
    {
        Debug.DrawRay(transform.position, lightSource.forward * 100, Color.yellow);
        if (Physics.Raycast(transform.position, lightSource.forward, out var hit, Mathf.Infinity))
        {
            shadow.gameObject.SetActive(true);
            shadow.position = hit.point;
            //shadow.forward = hit.normal;
            shadow.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
        }
        else
        {
            shadow.gameObject.SetActive(false);
        }
    }
}
