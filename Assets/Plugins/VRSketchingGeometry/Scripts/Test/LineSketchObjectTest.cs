﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRSketchingGeometry.SketchObjectManagement;
using VRSketchingGeometry.Serialization;

public class LineSketchObjectTest : MonoBehaviour
{
    public GameObject selectionPrefab;
    public GameObject LineSketchObjectPrefab;
    private LineSketchObject lineSketchObject;
    private LineSketchObject lineSketchObject2;

    private bool ranOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        lineSketchObject = Instantiate(LineSketchObjectPrefab).GetComponent<LineSketchObject>();
        lineSketchObject.setLineDiameter(.5f);
        lineSketchObject2 = Instantiate(LineSketchObjectPrefab).GetComponent<LineSketchObject>();
    }

    IEnumerator changeDiameter() {
        yield return new WaitForSeconds(5);
        lineSketchObject.setLineDiameter(.1f);
        yield return new WaitForSeconds(2);
        lineSketchObject.deleteControlPoint();
        lineSketchObject.deleteControlPoint();

    }

    IEnumerator deactivateSelection(SketchObjectSelection selection) {
        yield return new WaitForSeconds(3);
        selection.deactivate();
    }

    private void lineSketchObjectTest() {
        lineSketchObject.addControlPoint(new Vector3(-2, 1, 0));
        lineSketchObject.addControlPoint(Vector3.one);
        lineSketchObject.addControlPoint(new Vector3(2, 2, 0));
        lineSketchObject.addControlPoint(new Vector3(2, 1, 0));

        //lineSketchObject.setLineDiameter(.7f);
        StartCoroutine(changeDiameter());

        lineSketchObject2.addControlPoint(new Vector3(1,0,0));
        lineSketchObject2.addControlPoint(new Vector3(2, 1, 1));
        lineSketchObject2.addControlPoint(new Vector3(3, 2, 0));
        lineSketchObject2.minimumControlPointDistance = 2f;
        lineSketchObject2.addControlPointContinuous(new Vector3(3, 1, 0));

        //GameObject selectionGO = new GameObject("sketchObjectSelection", typeof(SketchObjectSelection));
        GameObject selectionGO = Instantiate(selectionPrefab);
        GameObject groupGO = new GameObject("sketchObjectGroup", typeof(SketchObjectGroup));
        SketchObjectSelection selection = selectionGO.GetComponent<SketchObjectSelection>();
        selection.addToSelection(lineSketchObject);
        selection.addToSelection(lineSketchObject2);
        selection.activate();
        StartCoroutine(deactivateSelection(selection));
    }

    private void groupSerializationTest()
    {
        lineSketchObject.addControlPoint(new Vector3(-2, 1, 0));
        lineSketchObject.addControlPoint(Vector3.one);
        lineSketchObject.addControlPoint(new Vector3(2, 2, 0));
        lineSketchObject.addControlPoint(new Vector3(2, 1, 0));

        //lineSketchObject.setLineDiameter(.7f);
        //StartCoroutine(changeDiameter());

        lineSketchObject2.addControlPoint(new Vector3(1, 0, 0));
        lineSketchObject2.addControlPoint(new Vector3(2, 1, 1));
        lineSketchObject2.addControlPoint(new Vector3(3, 2, 0));
        //lineSketchObject2.minimumControlPointDistance = 2f;
        //lineSketchObject2.addControlPointContinuous(new Vector3(3, 1, 0));
        GameObject groupGO = new GameObject("sketchObjectGroup", typeof(SketchObjectGroup));
        SketchObjectGroup group = groupGO.GetComponent<SketchObjectGroup>();
        group.addToGroup(lineSketchObject);
        group.addToGroup(lineSketchObject2);

        SketchObjectGroupData groupData = new SketchObjectGroupData(group);
        string xmlFilePath = Serializer.WriteTestXmlFile<SketchObjectGroupData>(groupData);
        Serializer.DeserializeFromXmlFile<SketchObjectGroupData>(out SketchObjectGroupData readGrouptData, xmlFilePath);
        Debug.Log(readGrouptData.SketchObjects[0].GetType());

        //GameObject selectionGO = new GameObject("sketchObjectSelection", typeof(SketchObjectSelection));
        //GameObject selectionGO = Instantiate(selectionPrefab);
        //SketchObjectSelection selection = selectionGO.GetComponent<SketchObjectSelection>();
        //selection.addToSelection(lineSketchObject);
        //selection.addToSelection(lineSketchObject2);
        //selection.activate();
        //StartCoroutine(deactivateSelection(selection));
    }

    // Update is called once per frame
    void Update()
    {
        if (!ranOnce) {
            //lineSketchObjectTest();
            groupSerializationTest();
            ranOnce = true;
        }
    }
}
