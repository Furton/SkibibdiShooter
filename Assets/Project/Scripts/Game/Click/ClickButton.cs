using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ClickButton : MonoBehaviour, IPointerClickHandler
{

    
    public GameObject clickPS;

    public UnityEvent OnClick;

    private Camera _cam;
    private ParticleSystem _ps;

    void Start()
    {
        _cam = Camera.main;
        _ps = clickPS.GetComponent<ParticleSystem>();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Vector3 pos = _cam.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 1000));
        clickPS.transform.position = new Vector3(pos.x, pos.y, clickPS.transform.position.z);
        _ps.Play();
        OnClick.Invoke();
    }

}
