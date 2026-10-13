using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class TimeLoop : MonoBehaviour
{
    public List<GameObject> Disabled = new List<GameObject>();
    public List<GameObject> Live = new List<GameObject>();
    Target tgt;
    public GameObject target;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public int count = 0;
    public int rnd = 1;
    public bool isLive;

    public int TargetOrder = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLive = target.activeSelf;
        
        spawnTargets();
        
        Debug.Log("um start works");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rnd > Live.Count)
        {
            isLive = true;
            StartCoroutine(makeLive());
        }
    }
    public void spawnTargets()
    { for (int i = 0; i < 29; i++)
        {
            float x = UnityEngine.Random.Range(-7.5f, 7.5f);
            float y = UnityEngine.Random.Range(-4.5f, 4.5f);

            Vector2 pos = new Vector2(x , y);
            
            GameObject GO = Instantiate(target, pos, target.transform.rotation);
            //tgt.gameObject.transform.position = pos;
            count++;
            //target.SetActive(false);
            Debug.Log("spawned");
            //StartCoroutine(slowSpawn());
            AddtoDisabled (GO);
        }

    }
    public void AddtoDisabled(GameObject t)
    {
        Disabled.Add(t);
        target.SetActive(false);
    }
    public IEnumerator makeLive()
    {
        Live.Add(Disabled[0]);
        Disabled.RemoveAt(0);

        foreach (GameObject t in Live)
        {
            Debug.Log(Live.Count);
            yield return new WaitForSeconds(2f);
            t.SetActive(true);
        }
        isLive = false;
    }
    private void OnMouseDown(Collider2D Target)
    {
        Live[TargetOrder].GetComponent<SpriteRenderer>().color = Color.green;
        TargetOrder++;
    }
}


// basically once you hit all the targets in the right order a new one will spawn in 
///Logic:
///max 30 
///my problem is keeping the list in order.
///what im thinking is that i instantiate a game object and put it in the list
///when the player's mouse clicks on a game object, if gameobject == next gameobject in list it will turn green
///when all objects are green (or when the list is empty start a corutine that waits 3 seconds
///after the 3 seconds go through the list again adding a new object
///End of logic
///List Application:
///Have a list With 30 instantiated objects all turned off, make sure they dont overlap
///when the user clicks an item that was lit up than it meets my condition 