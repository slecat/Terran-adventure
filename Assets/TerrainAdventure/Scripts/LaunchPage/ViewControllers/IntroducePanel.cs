using UnityEngine;
using QFramework;
using System.Collections;
using DG.Tweening;


// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace LaunchPage
{
	public partial class IntroducePanel : ViewController, IController
	{
		CanvasGroup canvasGroup;
		bool isOk;
		void Start()
		{
			// Code Here
			canvasGroup = GetComponent<CanvasGroup>();
		}
		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && !isOk)
			{
				isOk = true;
				StartCoroutine(IEToLogin());
			}
		}
		IEnumerator IEToLogin()
		{
			canvasGroup.DOFade(0, 1);
			yield return new WaitForSeconds(1);
			gameObject.SetActive(false);
			this.SendCommand<ShowLoginPanelCommand>();
		}

		public IArchitecture GetArchitecture()
		{
			return LaunchPage.Interface;
		}
	}
}
