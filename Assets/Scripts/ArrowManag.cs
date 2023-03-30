using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowManag : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject Player;
    public GameObject compass;

    private int n;
    private int index;

    private Vector3 position;
    private Vector3 orientation;
    private Vector3 up;
    private Vector3 objective;

    private float angle;
    private float previousAngle;
    private float distance;

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

        volume = 0.5f;
        pitch = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        n = checkpoints.Length;
        index = 0;

        position = Player.transform.position;
        orientation = Player.transform.forward;
        up = Player.transform.up;
        objective = checkpoints[0].transform.position;

        angle = 0;
        previousAngle = 0;
        distance = 0;

        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        position = Player.transform.position;
        orientation = Player.transform.forward;
        up = Player.transform.up;
        objective = checkpoints[index].transform.position;

        previousAngle = angle;
        angle = Vector3.SignedAngle(orientation, objective - position, up);

        distance = (objective - position).magnitude;


        compass.GetComponent<CanvasRenderer>().transform.RotateAround(compass.transform.position, compass.transform.forward, previousAngle - angle);

        if (distance < 5) {
            index++;
            source.Play();
            if (index >= n)
            {
                index = 0;
            }
        }

        source.volume = volume;
        source.pitch = pitch;
    }
}
