using UnityEngine;

public class StreetViewCamera : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;
    private Quaternion offset = Quaternion.identity;

    private GameManager gm;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            offset = Quaternion.Euler(90f, 0, 0);
        }

        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Vertical") * speed, -Input.GetAxis("Horizontal") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        transform.rotation = offset * GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}