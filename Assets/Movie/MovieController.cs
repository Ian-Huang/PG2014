using UnityEngine;
using System.Collections;

public class MovieController : MonoBehaviour
{
    public MovieTexture MovieClip;

    // Use this for initialization
    void Start()
    {
        this.renderer.material.mainTexture = this.MovieClip;
        this.MovieClip.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
