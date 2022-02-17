using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float timeCounter = 0;
    float speed;
    float width;
    float height;
    float axis;
    // Start is called before the first frame update
    void Start()
    {

        string name = gameObject.name;
        string last = name.Substring(name.Length - 1, 1);
        float.TryParse(last, out axis);

        speed = 0.1f * axis % 6;
        if (speed == 0) speed = 0.1f;
        width = 70;
        height = 70;
        axis = axis % 6;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        if (axis == 0) {

            float x = Mathf.Cos(timeCounter) * width;
            float y = Mathf.Sin(timeCounter) * height;
            float z = gameObject.transform.position.z;
            //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 270, 0);
            if (Mathf.Sin(timeCounter) * 90 > (Mathf.Sin(timeCounter - Time.deltaTime * speed) * 90)) gameObject.transform.eulerAngles = new Vector3(270 + Mathf.Sin(timeCounter) * 90, 270, 0);
            else gameObject.transform.eulerAngles = new Vector3(270 + 90 + (90 - Mathf.Sin(timeCounter) * 90), 270, 0);
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (axis == 1) {

            float x = Mathf.Cos(timeCounter) * width;
            float y = gameObject.transform.position.y;
            float z = 125f + Mathf.Sin(timeCounter) * height;
            if (Mathf.Sin(timeCounter) * 90 > (Mathf.Sin(timeCounter - Time.deltaTime * speed) * 90)) gameObject.transform.eulerAngles = new Vector3(270 + Mathf.Sin(timeCounter) * 90, 270, 0);
            else gameObject.transform.eulerAngles = new Vector3(180, 0 + 90 + (90 - Mathf.Sin(timeCounter) * 90), 90);
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (axis == 2) {

            float x = gameObject.transform.position.x;
            float y = Mathf.Cos(timeCounter) * width;
            float z = 125f + Mathf.Sin(timeCounter) * height;
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (axis == 3) {

            float x = 0 - Mathf.Cos(-1 * timeCounter) * width;
            float y = 0 - Mathf.Sin(-1 * timeCounter) * height;
            float z = gameObject.transform.position.z;
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (axis == 4) {

            float x = 0 - Mathf.Cos(-1 * timeCounter) * width;
            float y = gameObject.transform.position.y;
            float z = 125f - Mathf.Sin(-1 * timeCounter) * height;
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        if (axis == 5) {

            float x = gameObject.transform.position.x;
            float y = 0 - Mathf.Cos(-1 * timeCounter) * width;
            float z = 125f - Mathf.Sin(-1 * timeCounter) * height;
            gameObject.transform.position = new Vector3(x, y, z);
            if (z < 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            if (z > 90) gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
