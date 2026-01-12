using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] float xRotate = 0f;
    [SerializeField] float yRotate = 0f;
    [SerializeField] float zRotate = 0f;

    void Update()
    {
        transform.Rotate(xRotate * Time.deltaTime, yRotate * Time.deltaTime, zRotate * Time.deltaTime);
    }
}
