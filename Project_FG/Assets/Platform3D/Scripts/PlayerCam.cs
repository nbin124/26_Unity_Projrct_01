using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float rotSpeed = 200f;

    float mx;
    float my;

    public float rotaltelLimit = 80;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -rotaltelLimit, rotaltelLimit);

        transform.eulerAngles = new Vector3(-mx, mx, 0);
    }
}
