using UnityEngine;


public class camRotation : MonoBehaviour
{
    public float velRot = 0;
    int posY;
    Quaternion rot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            posY += 90;
            rot = Quaternion.Euler(0, posY, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            posY -= 90;
            rot = Quaternion.Euler(0, posY, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, velRot * Time.deltaTime);
    }
}
