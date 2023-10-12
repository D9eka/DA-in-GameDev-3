using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public float Speed = 0f;
    public static float BottomY = -30f;
    public GoogleSheetsController GSheetController;
    public AudioSource AudioSource;

    private void Start()
    {
        GSheetController = GameObject.FindWithTag("GSheetController").GetComponent<GoogleSheetsController>();
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return StartCoroutine(GSheetController.LoadData());
        Speed = GSheetController.DragonEggSpeedDataHandler.array[LevelController.GetLevelNumber() - 1];
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        AudioSource = GetComponent<AudioSource>();
        AudioSource.Play();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= Speed * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < BottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}
