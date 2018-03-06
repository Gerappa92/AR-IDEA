using Assets.Scripts.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLManager{

    public List<Furniture> LoadFurniture()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string streamingAssetsPath = Application.streamingAssetsPath;
            //Make sure your path doesn't miss any '/'
            string realPath = streamingAssetsPath + "/XML/list_furnitures.xml";
            WWW reader = new WWW(realPath);

            while (!reader.isDone)
            {
                //wait for the reader to finish downloading        
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Furniture>));
            MemoryStream stream = new MemoryStream(reader.bytes);


            if (stream != null)
            {
                List<Furniture> result = serializer.Deserialize(stream) as List<Furniture>;
                stream.Close();
                return result;
            }
            stream.Close();
            return null;    
        }
        else
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Furniture>));
            FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/list_furnitures.xml", FileMode.Open);
            List<Furniture> result = serializer.Deserialize(stream) as List<Furniture>;
            stream.Close();
            return result;
        }
    }
}
