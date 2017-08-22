using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialSystem : MonoBehaviour {

	public GameObject me;
	public GameObject text;
	public GameObject text2;
	public GameObject Acc;
	public GameObject touch;
	public int step=0;
	public int stepCount=0;	
	public int touchInfo;
	public int accInfo;

	public static int wantAcc=-9;

	// Use this for initialization
	void Start () {
		Config.ctrlCfg = false;
	}
	
	// Update is called once per frame
	void Update () {
		touchInfo= touch.GetComponent<touch> ().GetTouch() ;
		accInfo = Acc.GetComponent<GetAcc> ().getDirection() ;
		switch (step) {
		case 0:
			if(stepCount==1)messege ("Let's Start Tutorial!", "");
			if(stepCount==60)messege("Let's Start Tutorial!", "Tap the Screen");
			if (touchInfo == -1 && stepCount>60) {
				stepStep();
			}
			break;
		case 1:
			
			if (stepCount == 1) {
				messege ("がめんをかたむけてたまをうごかせるお", "");
				wantAcc = 1;
			}
			if (stepCount == 60) {
				messege ("がめんをかたむけてたまをうごかせるお", "みぎにかたむけてみよう");
			}
			if (accInfo == 1 && stepCount>60) {
				stepStep();
			}

			break;
		case 2:
			wantAcc = 3;
			if (stepCount == 1)
				messege ("はいプロ。", "");
			if (stepCount == 60)
				messege ("次は左にかたむけてみよう", "");
			if (accInfo == 3 && stepCount > 90) {
				//clearCount = stepCount;
				stepStep();
			}
			//if (stepCount - clearCount > 60) {
			//	stepStep ();
			//}
			break;
		case 3:
			wantAcc = 1;
			if(stepCount==1)messege ("いいね", "");
			if(stepCount==60)messege ("このままゴールまで運んでみよう！", "");
			if(stepCount==120)messege ("このままゴールまで運んでみよう！", "右にかたむけてみよう");
			if (accInfo == 1 && stepCount>150) {
				stepStep();
			}
			break;
		case 4:
			wantAcc = 2;
			if(stepCount==1)messege ("そのちょうし！", "");
			if(stepCount==60)messege ("つぎは上にかたむけてみよう！", "");
			if (accInfo == 2 && stepCount>150) {
				stepStep();
			}
			break;
		case 5:
			messege ("", "");
			break;
		default:
			step = 0;
			break;
		}
		stepCount++;
		//if(clearCount!=-1)clearCount++;
	}


	void messege(string text_,string text2_){
		//text = text.GetComponent<Text> ();
		text.GetComponent<Text> ().text = text_;
		//text2 = text2.GetComponent<Text> ();
		text2.GetComponent<Text> ().text = text2_;
	}

	void stepStep(){
		step++;
		stepCount = 0;
	}
}
	
