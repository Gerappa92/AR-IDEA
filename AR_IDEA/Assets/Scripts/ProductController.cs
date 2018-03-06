using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Models;
using System.Collections.Generic;

public class ProductController : MonoBehaviour {

    Canvas canvas;
    DefaultTrackableEventHandler[] defaultTrackableEventHandler;
    string FoundedName;
    Transform foundedObject3D;
    Text Text;
    DataBaseController _db;
    XMLManager xmlManager;
    List<Furniture> furnitures;

    public bool SetText { get; private set; }


    // Use this for initialization
    void Start () {
        canvas = gameObject.GetComponent<Canvas>();
        defaultTrackableEventHandler = FindObjectsOfType<DefaultTrackableEventHandler>();
        _db = new DataBaseController();
        xmlManager = new XMLManager();
        furnitures = xmlManager.LoadFurniture();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckTrackableEvent();        
    }


    public void Scale(bool large)
    {
        if (large)
        {
            foundedObject3D.parent.localScale += new Vector3(0.1f,0.1f,0.1f);
        }
        else
        {
            foundedObject3D.parent.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void Rotate(bool right)
    {
        if (right)
        {
            foundedObject3D.Rotate(Vector3.up, 200 * Time.deltaTime);
        }
        else
        {
            foundedObject3D.Rotate(Vector3.up, -200 * Time.deltaTime);
        }
    }

    private void CheckTrackableEvent()
    {
        if (defaultTrackableEventHandler.Any(item => item.found))
        {
            canvas.enabled = true;
            
            FoundedName =  defaultTrackableEventHandler.Where(item => item.found).FirstOrDefault().mTrackableBehaviour.TrackableName;
            foundedObject3D = GameObject.Find(FoundedName).transform.GetChild(0);

            if (!SetText)
            {
                SetPanel();
                SetText = true;
            }
        }
        else
        {
            canvas.enabled = false;
            SetText = false;
        }
    }

    private void SetPanel()
    {
        var furniture = furnitures.Where(item => item.Name == FoundedName).FirstOrDefault();

        Text = GameObject.Find("Name").GetComponent<Text>();
        Text.text = FoundedName;
        Text = GameObject.Find("Price").GetComponent<Text>();
        Text.text = furniture.Price.ToString("c");
        Text = GameObject.Find("Describe").GetComponent<Text>();
        Text.text = furniture.Describe;
        Text = GameObject.Find("Dimension").GetComponent<Text>();
        Text.text = furniture.Dimensions;
        Text = GameObject.Find("Number").GetComponent<Text>();
        Text.text = furniture.Number;
    }
}
