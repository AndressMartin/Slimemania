using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform alvo;
    private float velSuave = 0.45f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        Vector3 posDesejada = alvo.position + offset;

        //print(Vector3.Distance(transform.position, alvo.position));
        if (Vector3.Distance(transform.position, alvo.position) < 4f)
        {
            Vector3 posSuave = Vector3.SmoothDamp(transform.position, posDesejada, ref velocity, velSuave/1.5f);
            transform.position = posSuave;
            print("Perto!");
        }
        else if (Vector3.Distance(transform.position, alvo.position) >= 4f)
        {
            Vector3 posSuave = Vector3.SmoothDamp(transform.position, posDesejada, ref velocity, velSuave/1.3f);
            transform.position = posSuave;
            print("Longe!");
        }
        //transform.LookAt(alvo);
    }
}
