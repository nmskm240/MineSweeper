using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UniRx;

public class LongPressTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _pressed;
    private float _pressedTime;
    private IDisposable _disposable;

    public float Duration = 0.5f;
    public UnityEvent OnLongPressDown = new UnityEvent();
    public UnityEvent OnLongPressUp = new UnityEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
        if (_disposable == null)
        {
            _disposable = Observable.EveryUpdate().Subscribe(x =>
            {
                if (_pressed)
                {
                    _pressedTime += Time.deltaTime;
                    if (_pressedTime >= Duration)
                    {
                        _pressed = false;
                        OnLongPressDown.Invoke();
                    }
                }
            }).AddTo(this);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnLongPressUp.Invoke();
        _pressed = false;
        _pressedTime = 0f;
        _disposable.Dispose();
        _disposable = null;
    }
}