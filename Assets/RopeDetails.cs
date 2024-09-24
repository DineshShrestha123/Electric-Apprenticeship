using GogoGaga.OptimizedRopesAndCables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeDetails : MonoBehaviour
{
    [Header("Rope to End")]
    public Rope ropeToEnd;
    public Transform ropeToEndStartPos;
    public Transform ropeToEndFinalPos; 
    public Transform ropeToEndMiddlePos; 
    
    [Header("Rope to Start")]
    public Rope ropeToCreateNew;
    public Transform ropeToCreateStartPos;
    public Transform ropeToCreateFinalPos;
    public Transform ropeToCreateMiddlePos;

    [Header("GrabInteractablePos")]
    public GameObject grabInteractable;
    public Transform grabInteractablePos;

    [Header("Rope to End Left")]
    public Rope ropeLeftToEnd;
    public Transform ropeLeftToEndStartPos;
    public Transform ropeLeftToEndFinalPos;
    public Transform ropeLeftToEndMiddlePos;

    [Header("Rope to Start LEft")]
    public Rope ropeLeftToCreateNew;
    public Transform ropeLeftToCreateStartPos;
    public Transform ropeLeftToCreateFinalPos;
    public Transform ropeLeftToCreateMiddlePos;

    public Transform grabInteractableLeftPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
