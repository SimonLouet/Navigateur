using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System;

public class GeneratorWorld : MonoBehaviour
{
    public GameObject _world;
    
    // Start is called before the first frame update
    void Start()
    {
    
         string world = "{\n";
         world += "\"header\":{\n";
         world += "   \"user\":{\n";
         world += "       \"speed\":1,\n";
         world += "          \"transform\":{\n";
         world += "\"posY\":5\n";
         world += "}\n";
         world += "}\n";
         world += "},\n";
         world += "\"scene\":[\n";
   
         world += GetJson(_world);
         world += "\n]\n";
         world += "}\n";
   
        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("C:/Users/chloe/My project/World/world.json");
            //Write a line of text
            sw.WriteLine(world);
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string GetJson(GameObject obj){
    
    
    
    
        string data = "";
        data += "{\n";
           
        data += "    \"transform\":{\n";
        if(obj.transform.localPosition.x != 0){
            data += "        \"posX\":" + obj.transform.localPosition.x.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localPosition.y != 0){
            data += "        \"posY\":" + obj.transform.localPosition.y.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localPosition.z != 0){
            data += "        \"posZ\":" + obj.transform.localPosition.z.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localEulerAngles.x != 0){
            data += "        \"rotX\":" + obj.transform.localEulerAngles.x.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localEulerAngles.y != 0){
            data += "        \"rotY\":" + obj.transform.localEulerAngles.y.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localEulerAngles.z != 0){
            data += "        \"rotZ\":" + obj.transform.localEulerAngles.z.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localScale.x != 1){
            data += "        \"scaleX\":" + obj.transform.localScale.x.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localScale.y != 1){
            data += "        \"scaleY\":" + obj.transform.localScale.y.ToString().Replace(',', '.') + ",\n";
        }
        if(obj.transform.localScale.z != 1){
            data += "        \"scaleZ\":" + obj.transform.localScale.z.ToString().Replace(',', '.') + "\n";
        }
        data += "    },\n";
        data += "    \"type\":\"3DModel\",\n";
        
        GeneratorEntity entity = obj.GetComponent<GeneratorEntity>();   
        if(entity != null){
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>(); 
            if(renderer != null){
                data += "    \"mesh\":\"" + entity._mesh + "\",\n";
                data += "    \"meshCollider\":\"" + entity._mesh + "\",\n";
            }
            
            if(entity._script != ""){
                data += "    \"script\":\"" + entity._script + "\",\n";
            }
            
            if(entity._onUpdate != ""){
                data += "    \"onUpdate\":\"" + entity._onUpdate + "\",\n";
            }
            Debug.Log(obj.transform.name);
            Light light = obj.GetComponent<Light>(); 
            if(light != null){
            
                if(light.type == LightType.Spot){
                    data += "    \"lightType\":\"spot\",\n";
                    data += "    \"lightAngle\":\"" + light.spotAngle + "\",\n";
                    data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
                    data += "    \"lightRange\":\"" + light.range + "\",\n";
                    data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGBA(light.color) + "\",\n";
                }else if (light.type == LightType.Point){
                    data += "    \"lightType\":\"point\",\n";
                    data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
                    data += "    \"lightRange\":\"" + light.range + "\",\n";
                    data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGBA(light.color) + "\",\n";
                }else{
                    data += "    \"lightType\":\"directionnal\",\n";
                    data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
                    data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGBA(light.color) + "\",\n";
                }
            }
            
            
            
        }
        
        if(obj.transform.childCount > 0) {
            data += "    \"children\":[\n";
            
            for(int x = 0;x < obj.transform.childCount;x++){
                if(x > 0){
                    data += ",";
                }
                data += GetJson(obj.transform.GetChild(x).gameObject);
                
            }
            data += "   \n]\n";
        }
        
        
        data += "}";
        return data;
    }
}
