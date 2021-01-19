using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraRigScript : MonoBehaviour
{
	void FixedUpdate()
	{
		OVRInput.FixedUpdate();

		// コントローラのタッチパッドを取得
		Vector2 vector = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

		// カメラの位置を取得
		Transform transform = GetComponent<Transform>();

		// カメラの位置を取得
		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
		Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

		// カメラの位置をノーマライズ
		forward.Normalize();
		right.Normalize();

		// カメラの位置にトラックパッドの値を反映
		forward *= vector.y * Time.deltaTime;
		right *= vector.x * Time.deltaTime;

		// カメラの位置を更新
		transform.Translate(right + forward);
	}
}
