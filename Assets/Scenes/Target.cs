using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    TimeLoop TL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
  
    }
    void Start()
    {
        //TL.spawnTargets(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
