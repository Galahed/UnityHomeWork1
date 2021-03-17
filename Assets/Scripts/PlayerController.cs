using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Vector3 Direction1 = Vector3.forward;
    public Vector3 Direction2 = Vector3.left;
    private Rigidbody _rigidbody;
    private GameObject _level;
    private GameObject _default;
    private Text _text;
    public GameObject _button;
    public AudioSource audioSource;
    public float _speed = 1f;
    private bool _direction = true;
    private int _collected = 0;
    private bool _end = false;
    private int _turn = 1;

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
        //_button = GameObject.Find("Button");
        _rigidbody = GetComponent<Rigidbody>();
        _level = GameObject.Find("Level");
        _default = Instantiate(_level);
        _default.transform.position = new Vector3(0f, -20f, -20f);
        _default.SetActive(false);
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _direction = !_direction;

        }

    }

    private void FixedUpdate()
    {
        if (!_end)
        {
            Vector3 velocity = (_direction ? Direction1 : Direction2) * _speed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Fall"))
        {
            Debug.Log("Game over");
            _text.text = "Game over \n Result is " + _collected + " coins";
            gameObject.GetComponent<Renderer>().enabled = false;
            _end = true;
            _button.SetActive(true);
            /*          Vector3 velocity = Vector3.zero;
                        velocity.y = _rigidbody.velocity.y;
                        _rigidbody.velocity = velocity;
            */
        }
        if (other.CompareTag("Coin"))
        {
            _collected += 1;
            Debug.Log("Gold " + _collected);
            _text.text="Gold " + _collected;
            GetComponent<AudioSource>().Play(0);
            Destroy(other.gameObject);
            _speed = _speed * 1.05f;
            //_audioSource.outputAudio$$anonymousMixerGroup.audio$$anonymousMixer.SetFloat("$$anonymous$$ain$$anonymous$$ch", _speed);
            //audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1f / _musicSpeed);
            audioSource.pitch = 0.8f + _speed / 5;
        }
        if (other.CompareTag("Build"))
        {
            /*            
                        Debug.Log("Build trigger");
                        Vector3 _clonePosition = _level.GetComponent<Rigidbody>() .position;
                        Vector3 _cloneRotation = _level.transform.rotation;

                        _clonePosition.z = 10; 
                        GameObject _clone = Instantiate(_level, _clonePosition, _cloneRotation);
            */
            other.gameObject.SetActive(false);
            GameObject _clone = Instantiate(_default);
            _clone.transform.position = new Vector3(-3f * _turn,-1f,6f * _turn);
            _clone.transform.Rotate(0f, 0f, 0f, Space.Self);
            _clone.SetActive(true);
            _turn += 1;
        }
    }
}