using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class WallGenerator : MonoBehaviour {
	public GameObject wall;
	public GameObject top;
	public GameObject trap;
	public GameObject floor;
	public bool end = false;

	// Use this for initialization
	private int[,] A = new int[11,10]{
			{1,1,1,1,1,1,1,1,1,1},
			{0,1,1,0,0,0,0,0,1,0},
			{1,1,0,1,1,0,0,1,0,0},
			{0,0,1,0,0,1,1,1,1,0},
			{0,1,0,0,0,0,1,1,1,0},
			{1,0,0,0,1,1,1,0,0,1},
			{0,1,0,0,1,1,0,1,1,0},
			{0,0,1,1,0,1,1,0,0,0},
			{0,0,0,0,1,1,1,1,0,1},
			{0,0,1,1,0,1,1,0,1,0},
			{1,1,1,1,1,1,1,1,1,1}
		};

	private int[,] B = new int[10,11]{
			{1,0,0,0,1,1,0,1,0,0,1},
			{1,0,0,1,0,1,1,1,0,1,1},
			{1,0,1,0,1,0,1,0,0,1,1},
			{1,1,0,1,1,1,0,0,1,0,1},
			{1,0,1,1,1,1,0,0,1,0,1},
			{1,0,1,1,0,1,0,1,0,0,1},
			{1,1,0,0,1,0,1,0,1,1,1},
			{1,1,0,1,0,0,0,0,1,0,1},
			{1,1,1,0,1,0,0,0,1,0,1},
			{1,0,0,0,0,0,1,0,0,0,1}
		};

		GameObject[,] wallA = new GameObject[11,10];
		GameObject[,] topA = new GameObject[11,10];
		GameObject[,] wallB = new GameObject[10,11];
		GameObject[,] topB = new GameObject[10,11];
		GameObject tmp1, tmp2, tmp3;
		Canvas ExitCanvas;
		int count=0;
	void Start () {
		tmp3 = GameObject.Find("Trap_Fire");
		ExitCanvas = GameObject.Find("FinishCanvas").GetComponent<Canvas>();
		ExitCanvas.enabled = false;
		for(int i = 9; i >= 0; i--) {
			for(int j = 10; j >= 0; j--) {
				if (A[j,i] == 1) {
					wallA[j, i] = Instantiate(wall, new Vector3 ((j-5)*2.5F - 0.25F,0.3F,(i-5)*2.5F - 0.25F), Quaternion.identity);
					topA[j, i] = Instantiate(top, new Vector3 ((j-5)*2.5F - 0.25F,2.5F,(i-5)*2.5F - 0.25F), Quaternion.identity);
				}
				if (B[i,j] == 1) {
					wallB[i, j] =Instantiate(wall, new Vector3 ((i-5)*2.5F - 0.25F,0.3F,(j-5)*2.5F+0.25F), Quaternion.AngleAxis(90, new Vector3(0,1,0)));
					topB[i, j] =Instantiate(top, new Vector3 ((i-5)*2.5F - 0.25F,2.5F,(j-5)*2.5F+0.25F), Quaternion.AngleAxis(90, new Vector3(0,1,0)));
				}
				if (j < 10)Instantiate(floor, new Vector3 ((j-5)*2.5F - 0.25F,0,(i-5)*2.5F - 0.25F), Quaternion.identity);
			}
		}
		
		tmp1 = Instantiate(top, new Vector3 (3*2.5F - 0.25F,2.5F,2*2.5F+0.25F), Quaternion.AngleAxis(90, new Vector3(0,1,0)));
		tmp2 = Instantiate(trap, new Vector3 (3*2.5F +1.25F,2.5F,2*2.5F+0.25F), Quaternion.AngleAxis(90, new Vector3(0,1,0)));
		

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
			Application.Quit();
        }
		if (end) {
			count++;
			if (count < 1000) {
				for(int i = 9; i >= 0; i--) {
					for(int j = 10; j >= 0; j--) {
						if (A[j,i] == 1) {
							wallA[j, i].transform.position += new Vector3(0,0.05F,0);
							topA[j, i].transform.position += new Vector3(0,0.05F,0);
						}
						if (B[i,j] == 1) {
							wallB[i, j].transform.position += new Vector3(0,0.05F,0);
							topB[i, j].transform.position += new Vector3(0,0.05F,0);
						}
					}
				}
			
			tmp1.transform.position += new Vector3(0,0.05F,0);
			tmp2.transform.position += new Vector3(0,0.05F,0);
			tmp3.transform.position += new Vector3(0,0.05F,0);
			}
			else if (count == 1000){
				for(int i = 9; i >= 0; i--) {
					for(int j = 10; j >= 0; j--) {
						if (A[j,i] == 1) {
							Destroy(wallA[j, i],1.0F);
				 			Destroy(topA[j, i] ,1.0F);
						}
						if (B[i,j] == 1) {
							Destroy(wallB[i, j],1.0F);
				 			Destroy(topB[i, j] ,1.0F);
						}
					}
				}
				
			}
			if (count > 100) {
				Cursor.lockState =CursorLockMode.None;
				//GameObject.Find("FreeLookCameraRig").GetComponent<CursorLockMode>() = false;
				GameObject.Find("MapCanvas").GetComponent<Canvas>().enabled = false;
				ExitCanvas.enabled = true;
				Cursor.visible = true;
			}
		}

	}
	public void exitProgram(){
		Application.Quit();
	}
	public void loadScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}
}
