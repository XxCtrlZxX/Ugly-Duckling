﻿using UnityEngine;

public class World01_Summer : MonoBehaviour
{
    public CameraValue cameraValue;

    [SerializeField] GameObject background = default;
    [SerializeField] GameObject hills = default;
    [SerializeField] GameObject cloud = default;
    [SerializeField] GameObject floor = default;

    private float floorWidth, hillsWidth, cloudWidth;
    private float hillsOffset, cloudOffset;
    
    void Start()
    {
        // 바닥 가로 길이
        floorWidth = floor.GetComponent<SpriteRenderer>().size.x * floor.transform.localScale.x;
        // hill 가로 길이
        hillsWidth = hills.GetComponent<SpriteRenderer>().size.x * hills.transform.localScale.x;
        // 구름 가로 길이
        cloudWidth = cloud.GetComponent<SpriteRenderer>().size.x * cloud.transform.localScale.x;

        hillsOffset = hills.transform.position.x - cameraValue.cameraTarget.x;
        cloudOffset = cloud.transform.position.x - cameraValue.cameraTarget.x;
    }

    void FixedUpdate()
    {
        // floor 반복
        if (cameraValue.cameraTarget.x - floorWidth / 6 >= floor.transform.position.x)
            floor.transform.position += Vector3.right * floorWidth / 3;
        // hills 반복
        if (cameraValue.cameraTarget.x - cloudWidth / 4 >= hills.transform.position.x)
            hills.transform.position += Vector3.right * hillsWidth / 2;
        // cloud 반복
        if (cameraValue.cameraTarget.x - cloudWidth / 4 >= cloud.transform.position.x)
            cloud.transform.position += Vector3.right * cloudWidth / 2;
        
        // 배경 움직임
        MoveBgObject(background, 0, 1);
        MoveBgObject(hills, hillsOffset, 0.5f);
        MoveBgObject(cloud, cloudOffset, 0.8f);
    }
    
    private void MoveBgObject(GameObject gameObject, float offset, float ratio)
    {
        Vector3 pos = gameObject.transform.position;
        pos.x = Mathf.Lerp(pos.x, cameraValue.cameraTarget.x * ratio + offset, CameraValue.SmoothSpeed);
        gameObject.transform.position = pos;
    }
}
