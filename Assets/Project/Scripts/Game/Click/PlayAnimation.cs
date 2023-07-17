using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animation _anim;
    void Start()
    {
        _anim = GetComponent<Animation>();
    }

    public void PlayAnimationClip()
    {
        _anim.Play();
    }
}
