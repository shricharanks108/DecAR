using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public Selectable selected;
    public Text selectedText;
    public GameObject selectedFurnitureObject;
    public HSVPicker.ColorPicker picker;
    public Slider R;
    public Slider G;
    public Slider B;
    public Slider A; 

    public GameObject inventory;

    void Start()
    {
        RefreshColorPicker();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                var selectedObject = hit.transform;
                var selectable = selectedObject.gameObject.GetComponent<Selectable>();
                if (selectable != null)
                { 
                    if (!selectable.displayName.Equals(selected.displayName))
                    {
                        Destroy(selected.gameObject.GetComponent<HSVPicker.Examples.ColorPickerTester>());
                        selected = selectable;
                        selectedFurnitureObject = selectedObject.gameObject;
                        RefreshColorPicker();
                    }
                }
            }
        }

# if UNITY_EDITOR

        if(Input.GetMouseButtonDown(0))
        { 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                var selectedObject = hit.transform;
                var selectable = selectedObject.gameObject.GetComponent<Selectable>();
                if (selectable != null)
                {
                    if (!selectable.displayName.Equals(selected.displayName))
                    {
                        Destroy(selected.gameObject.GetComponent<HSVPicker.Examples.ColorPickerTester>());
                        selected = selectable;
                        selectedFurnitureObject = selectedObject.gameObject;
                        RefreshColorPicker();
                    }
                }
            }
        }

# endif

    }

    void RefreshColorPicker()
    {
        selectedText.text = selected.displayName;
        MeshRenderer selectedObjectRenderer = selectedFurnitureObject.GetComponent<MeshRenderer>();
        selectedFurnitureObject.AddComponent<HSVPicker.Examples.ColorPickerTester>();
        R.value = selectedObjectRenderer.material.color.r;
        G.value = selectedObjectRenderer.material.color.g;
        B.value = selectedObjectRenderer.material.color.b;
        A.value = selectedObjectRenderer.material.color.a;
        selectedFurnitureObject.GetComponent<HSVPicker.Examples.ColorPickerTester>().renderer = selectedObjectRenderer;
        selectedFurnitureObject.GetComponent<HSVPicker.Examples.ColorPickerTester>().picker = this.picker;
        selectedObjectRenderer.material.color = new Color(R.value, G.value, B.value, A.value);

        Color color = selectedObjectRenderer.material.color;
        picker.CurrentColor = color;
    }

    void HideColorPicker()
    {
        GameObject colpick = picker.gameObject;
        colpick.SetActive(false);
    }

    void ShowColorPicker()
    {
        GameObject colpick = picker.gameObject;
        colpick.SetActive(true);
    }

    public void ColorPickerToggle()
    {
        if (picker.isActiveAndEnabled)
        {
            HideColorPicker();
        }
        else
        {
            ShowColorPicker();
        }
    }

    public void InventoryToggle()
    {
        if (inventory.activeInHierarchy)
        {
            
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }

}
