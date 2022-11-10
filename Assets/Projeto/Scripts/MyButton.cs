using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    
    [SerializeField]
    public bool buttonPressed;
    
    private PlayerController _PlayerController;

    void Start()
    {

        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        
    }

    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
        _PlayerController.JumpOff();    
    }
    
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
        _PlayerController.Jump();

    }
}