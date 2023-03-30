using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundLauncher : MonoBehaviour
{
    private GameObject Player;
    private Vector3 position;
    private Vector3 orientation;
    private Vector3 up;
    private Vector3 objective;

    private float angle;
    private float previousAngle;
    private float distance;

    private bool isPlaying = false;

    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source;

    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();

        Player = GameObject.Find("CenterEyeAnchor");

        volume = 0.5f;
        pitch = 1f;
    }


    // Start is called before the first frame update
    void Start()
    {
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;

        position = Player.transform.position;
        orientation = Player.transform.forward;
        up = Player.transform.up;
        objective = transform.position;

        angle = 0;
        previousAngle = 0;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = volume;
        source.pitch = pitch;

        position = Player.transform.position;
        orientation = Player.transform.forward;
        up = Player.transform.up;
        objective = transform.position;

        previousAngle = angle;
        angle = Vector3.SignedAngle(orientation, objective - position, up);

        distance = (objective - position).magnitude;

        if (distance < 10 && !isPlaying)
        {
            isPlaying = true;
            source.Play();
            Debug.Log("son  lance --------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }

    public void PlaySound()
    {
        source.Play();
        Debug.Log("Son de voiture lancé");
    }

}
