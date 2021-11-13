using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{   
    public CharacterController _controller;
    public GameObject _camera;
    public GameObject _entityOver;
    
    public bool _isGrounded;
    public float _speedMove = 2.0f;
    public float _jumpHeight = 1.0f;
    public float _gravity = -9.81f;
    public float _speedRotationY = 10;
    public float _speedRotationX = 10;
    
    private Vector3 playerVelocity;
    
            
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    void OnGUI()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
        
        _isGrounded = _controller.isGrounded;
        if (_isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        if(!Navigator._interface.activeSelf){
            _controller.Move(Time.deltaTime * _speedMove * ((gameObject.transform.right * Input.GetAxis("Horizontal")) + (gameObject.transform.forward * Input.GetAxis("Vertical"))));
            
            transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + Time.deltaTime * _speedRotationY * Input.GetAxis("Mouse X"),0);         
            _camera.transform.localEulerAngles = new Vector3(_camera.transform.localEulerAngles.x + Time.deltaTime * _speedRotationX * -Input.GetAxis("Mouse Y"),0,0);  
        }
        
        
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }

        playerVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
        if(!Navigator._interface.activeSelf){
            RaycastHit hit;
            EntityComponent entityComponent;  
            if (Physics.Raycast(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward), out hit))
            {
                if(hit.transform.gameObject != _entityOver){
                    if(_entityOver != null){
                        entityComponent = _entityOver.GetComponent<EntityComponent>();
                        if(entityComponent != null){
                            entityComponent._entity.OnMouseOut();
                        }
                    }
                    _entityOver = hit.transform.gameObject;
                    entityComponent = _entityOver.GetComponent<EntityComponent>();
                    if(entityComponent != null){
                        entityComponent._entity.OnMouseOver();
                    }
                }
                if (Input.GetMouseButtonDown(0)){
                    entityComponent = _entityOver.GetComponent<EntityComponent>();
                    if(entityComponent != null){
                        entityComponent._entity.OnClick();
                    }
                }
            }
            else
            {
                if(_entityOver != null){
                    entityComponent = _entityOver.GetComponent<EntityComponent>();
                    if(entityComponent != null){
                        entityComponent._entity.OnMouseOut();
                    }
                    _entityOver = null;
                }
                
                
            }
        
        
        }
        
        
    }
    
    public void SetPosition(Vector3 position){
        playerVelocity.y = 0f;
        
        _controller.Move(position - transform.position );
    }
    
    
    public void SetRotation(Vector3 rotation){
        playerVelocity.y = 0f;
        transform.localEulerAngles = rotation;
    }
    
}
