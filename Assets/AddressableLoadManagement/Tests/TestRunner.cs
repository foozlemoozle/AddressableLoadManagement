using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace com.keg.addressableloadmanagement.tests
{
	[CustomEditor( typeof( TestRunner ) )]
	public class TestRunnerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if( !Application.isPlaying )
			{
				return;
			}

			TestRunner testRunner = target as TestRunner;
			if( testRunner == null )
			{
				return;
			}

			IAddressableLoader loader = null;
			if( GUILayout.Button( "Load GameObject" ) )
			{
				loader.Load<GameObject>(
					"Assets/AddressableLoadManagement/Tests/Loadable/TestAddressablePrefab.prefab",
					"TestGroup",
					testRunner.OnGameObjectLoaded );
			}

			if( GUILayout.Button( "Unload GameObject" ) )
			{
				testRunner.PopTopGameObject().ReleaseAddressable();
			}

			if( GUILayout.Button( "Load ScriptableObject" ) )
			{
				loader.Load<TestScriptableObject>(
					"Assets/AddressableLoadManagement/Tests/Loadable/TestSO.asset",
					"TestGroup",
					testRunner.OnSOLoaded );
			}

			if( GUILayout.Button( "Unload ScriptableObject" ) )
			{
				testRunner.PopTopSO().ReleaseAddressable();
			}
		}
	}
}
#endif

namespace com.keg.addressableloadmanagement.tests
{
	public class TestRunner : MonoBehaviour
	{
		private Stack<GameObject> _loadedGameObjects = new Stack<GameObject>();
		private Stack<TestScriptableObject> _loadedSOs = new Stack<TestScriptableObject>();

		public void OnGameObjectLoaded( GameObject asset )
		{
			GameObject instantiated = GameObject.Instantiate<GameObject>( asset );
			_loadedGameObjects.Push( instantiated );
		}

		public GameObject PopTopGameObject()
		{
			if( _loadedGameObjects.Count == 0 )
			{
				return null;
			}
			return _loadedGameObjects.Pop();
		}

		public void OnSOLoaded( TestScriptableObject so )
		{
			Debug.Log( so.test );
			_loadedSOs.Push( so );
		}

		public TestScriptableObject PopTopSO()
		{
			if( _loadedSOs.Count == 0 )
			{
				return null;
			}

			return _loadedSOs.Pop();
		}
	}
}
