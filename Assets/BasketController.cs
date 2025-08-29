using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        aud =GetComponent<AudioSource>();
        director =GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,Mathf.Infinity)) {
                float x =Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x,0,z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="apple") {
            aud.PlayOneShot(appleSE);
            director.GetComponent<GameDirector>().GetApple();
        } else if (other.gameObject.tag == "bomb") {
            aud.PlayOneShot(bombSE);
            director.GetComponent<GameDirector>().GetBomb();
           }
        Destroy(other.gameObject);
    }
}
