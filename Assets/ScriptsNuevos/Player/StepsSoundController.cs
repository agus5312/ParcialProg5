using UnityEngine;

public class StepsSoundController : MonoBehaviour
{
    AudioSource stepsSound;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip run;
    bool moviendose;

    StarterAssets.FirstPersonController firstPersonController;
    StarterAssets.StarterAssetsInputs inputs;

    Controles controls = null;

    private void Awake()
    {
        controls = new Controles();

        controls.Player.Run.started += ctx => RunSound();
        controls.Player.Run.canceled += ctx => WalkSound();

        stepsSound = GetComponent<AudioSource>();
        firstPersonController = FindObjectOfType<StarterAssets.FirstPersonController>();
        inputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Pasos();
    }

    void Pasos()
    {
        if (inputs.move != new Vector2(0, 0) && firstPersonController.Grounded)
        {
            if (moviendose == false)
            {
                stepsSound.Play();
            }
            moviendose = true;
        }
        else
        {
            stepsSound.Stop();
            moviendose = false;
        }
    }

    void WalkSound()
    {
        stepsSound.clip = walk;
        stepsSound.Play();
    }

    void RunSound()
    {
        stepsSound.clip = run;
        stepsSound.Play();
    }
}
