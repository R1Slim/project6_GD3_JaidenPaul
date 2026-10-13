using UnityEngine;

public class Crosshairmovement : MonoBehaviour
{
    public GameObject CRGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      CRGO = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
