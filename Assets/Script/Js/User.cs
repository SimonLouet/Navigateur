using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class User{
    private float _speed;
    private TransformWeb _transform;
    
    private GameObject _gameObject;
    
    public User(){
        SetTransform(new TransformWeb());
        SetSpeed(5.0f);
        
        var character = Resources.Load<GameObject>("Character");
        _gameObject = GameObject.Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity);
        _transform.SetTransform(_gameObject.transform);
    }
    
    
    public User(string json){
        var values =  JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        if(values.ContainsKey("speed")){
            SetSpeed(Convert.ToSingle(values["speed"]));
        }else{
            SetSpeed(5.0f);
        }
        
        if(values.ContainsKey("transform")){
            SetTransform(new TransformWeb(values["transform"].ToString()));
        }else{
            SetTransform(new TransformWeb());
        }
        
        var character = Resources.Load<GameObject>("Character");
        _gameObject = GameObject.Instantiate(character, new Vector3(0, 0, 0), Quaternion.identity);
        _transform.SetTransform(_gameObject.transform);
        
    }
    
    
    //Speed
    public float GetSpeed(){
        return _speed;
    }
    
    public void SetSpeed(float speed){
        _speed = speed;
    }
    
    
    //Transform
    public TransformWeb GetTransform(){
        return _transform;
    }
    
    public void SetTransform(TransformWeb transform){
        _transform = transform;
    }
    
    public void Destroy()
    {
        GameObject.Destroy(_gameObject);
        _transform.Destroy();
    }
}