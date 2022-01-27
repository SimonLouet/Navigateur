using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System;
using TMPro;

public class GeneratorWorld : MonoBehaviour
{
    public GameObject _world;
    public string _adresse;
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
        
        
        TextMeshPro textMesh = obj.GetComponent<TextMeshPro>(); 
        if(textMesh != null){
            data += "    \"text\":\"" + textMesh.text.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            data += "    \"textColor\":\"#" + ColorUtility.ToHtmlStringRGBA(textMesh.color) + "\",\n";
            data += "    \"textSize\":\"" + textMesh.fontSize + "\",\n";
            
                
                
            if(textMesh.alignment == TextAlignmentOptions.TopLeft){
                data += "    \"textAlignment\":\"Upper-Left\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.Top){
                data += "    \"textAlignment\":\"Upper-Center\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.TopRight){
                data += "    \"textAlignment\":\"Upper-Right\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.Left){
                data += "    \"textAlignment\":\"Middle-Left\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.Center){
                data += "    \"textAlignment\":\"Middle-Center\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.Right){
                data += "    \"textAlignment\":\"Middle-Right\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.BottomLeft){
                data += "    \"textAlignment\":\"Lower-Left\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.Bottom){
                data += "    \"textAlignment\":\"Lower-Center\",\n";
            }else if(textMesh.alignment == TextAlignmentOptions.BottomRight){
                data += "    \"textAlignment\":\"Lower-Right\",\n";
            }    
            
            
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            if(rectTransform != null){
                data += "    \"textWidth\":\"" + rectTransform.sizeDelta.x + "\",\n";
                data += "    \"textHeight\":\"" + rectTransform.sizeDelta.y + "\",\n";
                
            }
            
        }/*else{
          MeshFilter renderer = obj.GetComponent<MeshFilter>(); 
          if(renderer != null){
              if(renderer.sharedMesh.name == "Cube"){
                  data += "    \"mesh\":\"local:cube\",\n";
                  data += "    \"meshCollider\":\"local:cube\",\n";
              }else{
                  data += "    \"mesh\":\"" + _adresse+"/obj/"+ renderer.sharedMesh.name + ".obj\",\n";
                  data += "    \"meshCollider\":\"" + _adresse+"/obj/"+ renderer.sharedMesh.name + ".obj\",\n";
              }
              
          }
        
        }*/
            
        Light light = obj.GetComponent<Light>(); 
        if(light != null){
            if(light.type == LightType.Spot){
                data += "    \"lightType\":\"spot\",\n";
                data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGB(light.color) + "\",\n";
                data += "    \"lightRange\":\"" + light.range + "\",\n";
                data += "    \"lightAngle\":\"" + light.spotAngle + "\",\n";
                data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
            }else if (light.type == LightType.Point){
                data += "    \"lightType\":\"point\",\n";
                data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGB(light.color) + "\",\n";
                data += "    \"lightRange\":\"" + light.range + "\",\n";
                data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
            }else if (light.type == LightType.Directional){
                data += "    \"lightType\":\"directional\",\n";
                data += "    \"lightColor\":\"#" + ColorUtility.ToHtmlStringRGB(light.color) + "\",\n";
                data += "    \"lightIntensity\":\"" + light.intensity + "\",\n";
            }
        }
        
               
        GeneratorEntity entity = obj.GetComponent<GeneratorEntity>();   
        if(entity != null){
            if(entity._id != ""){
                data += "    \"id\":\"" + entity._id + "\",\n";
            }
            if(entity._type != ""){
                data += "    \"type\":\"" + entity._type + "\",\n";
            }
            if(entity._mesh != ""){
                data += "    \"mesh\":\"" + entity._mesh + "\",\n";
                data += "    \"meshCollider\":\"" + entity._mesh + "\",\n";
            }
            
            if(entity._texture != ""){
                data += "    \"texture\":\"" + entity._texture + "\",\n";
            }
            
            
            if(entity._script != ""){
                data += "    \"script\":\"" + entity._script.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            
            if(entity._onClick != ""){
                data += "    \"onClick\":\"" + entity._onClick.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            
            if(entity._onMouseOver != ""){
                data += "    \"onMouseOver\":\"" + entity._onMouseOver.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onMouseOut != ""){
                data += "    \"onMouseOut\":\"" + entity._onMouseOut.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onUpdate != ""){
                data += "    \"onUpdate\":\"" + entity._onUpdate.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onChangeValue != ""){
                data += "    \"onChangeValue\":\"" + entity._onChangeValue.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onKey != ""){
                data += "    \"onKey\":\"" + entity._onKey.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onFocus != ""){
                data += "    \"onFocus\":\"" + entity._onFocus.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._onBlur != ""){
                data += "    \"onBlur\":\"" + entity._onBlur.Replace("\"", "\\\"").Replace(Environment.NewLine, "\\n") + "\",\n";
            }
            if(entity._href != ""){
                data += "    \"href\":\"" + entity._href + "\",\n";
            }
            Debug.Log(obj.transform.name);
            
            
            
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
