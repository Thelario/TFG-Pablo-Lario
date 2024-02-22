using _Project.COMMON.Scripts.Manager_Helpers;
using UnityEngine;

namespace _Project.MONO.Scripts
{
	public class CameraScaler : Singleton<CameraScaler>
	{
		[SerializeField] private float scaleFactor;
		[SerializeField] private float zScaleMultiplier;
		[SerializeField] private Transform thisTransform;

		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Q))
				return;
			
			ScaleCamera();
		}

		private void ScaleCamera()
		{
			thisTransform.position += new Vector3(0f, scaleFactor, -scaleFactor * zScaleMultiplier);
		}
	}
}
