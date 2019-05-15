﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowers_Buying : TradeCupcakeTower
{

    // 팔고자 하는 컵케이크 타워 GameObject
    public GameObject cupcakeTowerPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // 타워의 초기 금액 정보 찾아옴
        int price = cupcakeTowerPrefab.GetComponent<CupcakeTowerScript>().initialCost;
        // 슈거미터를 정의 안해줘서 그런가? 수정
        // sugarMeter = GetComponent<SugarMeterScript>().sugarMeter;
        // 타워를 현재 구매할 수 있는가?
        if (price <= sugarMeter.getSugarAmount()) // 확인 필요 부분 // sugarMeter가 현재 null이다.
        {
            // 금액을 슈거에서 차감
            sugarMeter.ChangeSugar(-price);
            // 새로운 컵케이크 타워 생성
            GameObject newTower = Instantiate(cupcakeTowerPrefab);
            // 새로운 컵케이크 타워가 현재 선택된 타워로 지정
            currentActiveTower = newTower.GetComponent<CupcakeTowerScript>();
        }
    }
}
