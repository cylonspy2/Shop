using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemController : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float force;

    private Rigidbody rgbd;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        rgbd = GetComponent<Rigidbody>();
        StartCoroutine("ChangeColor");
    }

    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);

        Color color = Random.ColorHSV(0.3f, 1, 0.3f, 1, 0.3f, 1);
        material.DOColor(color, duration);
    }

    public void Push()
    {
        rgbd.AddForce(transform.right * force);
    }
}
