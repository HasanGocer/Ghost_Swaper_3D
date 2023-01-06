using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f; // Player movement speed
    public Joystick joystick; // The instantiated joystick object
    public Rigidbody rb; // The rigidbody component
    private Touch touch; // The touch component

    void Update()
    {
        if (Input.touchCount > 0 && GameManager.Instance.isStart)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                joystick.gameObject.SetActive(true);
                joystick.transform.position = touch.position;
                joystick.transform.rotation = Quaternion.identity;
                GhostManager.Instance.animController.CallWalkAnim();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = touch.position;
                joystick.OnPointerDown(eventData);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                joystick.OnPointerUp(new PointerEventData(EventSystem.current));
                joystick.gameObject.SetActive(false);
                GhostManager.Instance.animController.CallIdleAnim();
            }

            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            // Hareket ve rotasyon için yön vektörünü kullanýn
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

            // Eðer yön vektörü sýfýrdan büyükse, oyuncu karakterinin rotasyonunu deðiþtirin
            if (direction.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }
}
