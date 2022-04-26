using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _joystickPoint;
    [SerializeField] private PlaneMover _planeMover;

    private float _maxRadius;
    private Vector2 _direction;

    private void Start()
    {
        _joystickPoint.transform.position = transform.position;
        _maxRadius = 0.7f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosotion = Camera.main.ScreenToWorldPoint(eventData.position);
        _direction = new Vector2(mousePosotion.x - transform.position.x, mousePosotion.y - transform.position.y);

        if (Vector2.SqrMagnitude(_direction) < _maxRadius)
            _joystickPoint.transform.position = new Vector3(mousePosotion.x, mousePosotion.y , transform.position.z);
        else
        {
            Vector2 delta = new Vector2(mousePosotion.x - transform.position.x, mousePosotion.y - transform.position.y);
            Vector2 state = Vector2.ClampMagnitude(delta, _maxRadius);
            _joystickPoint.transform.position = new Vector3(state.x + transform.position.x, state.y + transform.position.y, transform.position.z);
        }

        Vector2 planeDirection = new Vector2(_direction.x, _direction.y).normalized;
        _planeMover.AdjustmentDirection(planeDirection);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _joystickPoint.transform.position = transform.position;
    }
}
