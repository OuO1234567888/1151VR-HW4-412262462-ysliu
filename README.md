1. 專案截圖
![image](https://github.com/OuO1234567888/1151VR-HW4-412262462-ysliu/blob/main/1151VR-HW4-%E6%88%AA%E5%9C%96.png)

2. github連結
https://github.com/OuO1234567888/1151VR-HW4-412262462-ysliu

3. youtube連結
https://youtu.be/D-CEXTy671E

4. 說明製作流程和相關操作
載入飛行器和障礙物模型，各自加上Collider，飛行器加上Rigidbody，利用OnCollisionEnter實作撞到障礙物撥放音效，z軸座標大於20時視為通過障礙物並撥放音效，在Start裡循環撥放飛行音效，在UI按鈕上加上Event Trigger組件，在按下和放開時控制飛行器參數實作移動。
