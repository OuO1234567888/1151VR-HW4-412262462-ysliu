using System.Collections;
using UnityEngine;

public class HelicopterControl : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip helicopterSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip winSound;
    bool winSoundLock = false;
    float speed = 10f;
    [HideInInspector]
    public bool forward = false; 
    [HideInInspector]
    public bool back = false; 
    [HideInInspector]
    public bool left = false; 
    [HideInInspector]
    public bool right = false; 
    [HideInInspector]
    public bool up = false; 
    [HideInInspector]
    public bool down = false; 
    Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = helicopterSound;
        audioSource.loop = true;
        audioSource.Play();

        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if(forward)
        {
            velocity += transform.forward * speed;
        }
        if(back)
        {
            velocity -= transform.forward * speed;
        }
        if(left)
        {
            velocity -= transform.right * speed;
        }
        if(right)
        {
            velocity += transform.right * speed;
        }
        if(up)
        {
            velocity += transform.up * speed;
        }
        if(down)
        {
            velocity -= transform.up * speed;
        }
        gameObject.transform.position += velocity * Time.deltaTime;

        if(gameObject.transform.position.z > 20f && winSoundLock == false)
        {
            audioSource.PlayOneShot(winSound);
            winSoundLock = true;
            StartCoroutine(GoToStartPoint());
        }
    }

    public void setForward(bool value)
    {
        forward = value;
    }
    public void setBack(bool value)
    {
        back = value;
    }
    public void setLeft(bool value)
    {
        left = value;
    }
    public void setRight(bool value)
    {
        right = value;
    }
    public void setUp(bool value)
    {
        up = value;
    }
    public void setDown(bool value)
    {
        down = value;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(hitSound);
        }
        
    }

    IEnumerator GoToStartPoint()
    {
        yield return new WaitForSeconds(2);
        gameObject.transform.position = startPos;
        winSoundLock = false;
    }
}
