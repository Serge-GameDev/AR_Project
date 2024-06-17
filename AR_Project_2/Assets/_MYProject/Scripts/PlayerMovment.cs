using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform gamePad;
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] GameObject player;
    Vector3 move;

    bool walking;
    Coroutine movementCoroutine;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        // Correctly compute the move direction in local space
        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized;

        if (!walking)
        {
            walking = true;
            player.GetComponent<Animator>().SetBool("Walk", true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (movementCoroutine == null)
        {
            movementCoroutine = StartCoroutine(PlayerARMovement());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        walking = false;
        player.GetComponent<Animator>().SetBool("Walk", false);

        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
            movementCoroutine = null;
        }
    }

    IEnumerator PlayerARMovement()
    {
        while (true)
        {
            player.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)
            {
                // Smooth rotation towards movement direction
                player.transform.rotation = Quaternion.Slerp(
                    player.transform.rotation,
                    Quaternion.LookRotation(move),
                    Time.deltaTime * 15f
                );
            }
            yield return null;
        }
    }
}
