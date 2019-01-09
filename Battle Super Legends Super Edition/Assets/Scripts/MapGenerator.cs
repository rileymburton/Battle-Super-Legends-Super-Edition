using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public List <int> spawnDirections = new List<int>();
	public List <string> roomExitType = new List<string>();	

	public List <int> xPosition = new List<int>();
	public List <int> yPosition = new List<int>();
	public GameObject roomA;
	public GameObject roomB;
	public GameObject roomC;
	public GameObject roomD;

	public GameObject roomE;
	public GameObject roomF;
	public GameObject roomG;
	public GameObject roomH;
	public GameObject roomI;
	public GameObject roomJ;

	public GameObject roomLeftExitY;
	public GameObject roomRightExitZ;
	public GameObject roomBottomExitYZ;
	public GameObject roomTopExitYZ;


	private int numberOfRooms;

	private int startRoomNum;
	
	private int endRoomNum; 

	private int randomRoomElementNumber;


	// Use this for initialization
	void Start () {
		
		numberOfRooms = Random.Range(100,200);
		Debug.Log("Number of Rooms = " + numberOfRooms);
		GenerateMap();
		AssignRoomCode();
		PlaceRooms();
		PlaceRandomRooms();
	//	UpdateRoomCode();
		InstantiateRooms();
	}
	
	private void GenerateMap(){
		//0 is up
		//1 is right
		//2 is down
		int nextRoomDirection;  //sets to a random number between 0 and 2
		int previousRoomDirection = -1;
		for(int i = 0; i < numberOfRooms; i++){
			if(previousRoomDirection == 0){
				nextRoomDirection = Random.Range(0,2);
			}
			else if (previousRoomDirection == 2){
				nextRoomDirection = Random.Range(1,3);
			}
			else {
				nextRoomDirection = Random.Range(0,3);
			}
			previousRoomDirection = nextRoomDirection;
			Debug.Log(nextRoomDirection);
			spawnDirections.Add(nextRoomDirection);
			

		}

	}

	private void AssignRoomCode() {
		roomExitType.Add("Z");
		for (int i = 1; i < numberOfRooms-1; i++){

			if(spawnDirections[i+1] == 0 && spawnDirections[i] == 0){
				roomExitType.Add("A");
			}
			else if(spawnDirections[i+1] == 2 && spawnDirections[i] == 2){
				roomExitType.Add("A");
			}

			else if (spawnDirections[i+1] == 1 && spawnDirections[i] == 2) {
				roomExitType.Add("B");
			}

			else if(spawnDirections[i+1] == 1 && spawnDirections[i] == 1){
				roomExitType.Add("C");
			}

			else if(spawnDirections[i+1] == 1 && spawnDirections[i] == 0){
				roomExitType.Add("D");
			}
	
			else if (spawnDirections[i+1] == 2 && spawnDirections[i] == 1){
				roomExitType.Add("E");
			}

			else if(spawnDirections[i+1] == 0 && spawnDirections[i] == 1){
				roomExitType.Add("F");
			}
			else{
		}
		}
		
		roomExitType.Add("Y");
		foreach(string x in roomExitType){
			Debug.Log(x);
		}
	}

	private void PlaceRooms(){
		int xDisplacement = 0;
		int yDisplacement = 0;


			for(int i=0; i < numberOfRooms; i++){
				

				if(roomExitType[i] == "A"){
				//Instantiate(roomA, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
				xPosition.Add(xDisplacement);
				yPosition.Add(yDisplacement);
					if(spawnDirections[i] == 0){
						yDisplacement += 10;
					} else {
						yDisplacement -= 10;
					}
				}
				else if(roomExitType[i] == "B"){
					//Instantiate(roomB, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);
					xDisplacement += 10;
				}
				else if(roomExitType[i] == "C"){
					//Instantiate(roomC, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);					
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "D"){
					//Instantiate(roomD, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "E"){
					//Instantiate(roomE, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else if (roomExitType[i] == "F"){
					//Instantiate(roomF, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement+= 10;
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 0){
					//Instantiate(roomBottomExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 1){
					//Instantiate(roomLeftExitY, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 2){
					//Instantiate(roomTopExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}

				
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 1){
					//Instantiate(roomRightExitZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 0){
					//Instantiate(roomTopExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 2){
					//Instantiate(roomBottomExitYZ, new Vector2(xDisplacement, yDisplacement), Quaternion.identity);
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else {
					Debug.LogError("INVALID SPAWN DIRECTION" + i);
					Debug.Log(roomExitType[i]);
					Debug.Log(spawnDirections[i]);
				}
			}
		}

		private void PlaceRandomRooms(){
		randomRoomElementNumber = Random.Range(5, 10);
		for(int i = randomRoomElementNumber; i <numberOfRooms -1; i += Random.Range(5,10)){
			bool canGoUp = true;
			bool canGoRight = true;
			bool canGoDown = true;
			bool canGoLeft = true;
			int currentXPosition = xPosition[i];
			int currentYPosition = yPosition[i];
			Debug.Log(i);
			Debug.Log(currentXPosition + " " + currentYPosition);
			for(int j = 0; j < xPosition.Count; j++){
				if(xPosition[j] == currentXPosition && yPosition[j] == currentYPosition + 10){
					canGoUp = false;
				}
				if(xPosition[j] == currentXPosition + 10 && yPosition[j] == currentYPosition){
					canGoRight = false;
				}
				if(xPosition[j] == currentXPosition && yPosition[j] == currentYPosition - 10){
					canGoDown = false;
				}
				if(xPosition[j] == currentXPosition - 10 && yPosition[j] == currentYPosition){
					canGoLeft = false;
				}
				if(!canGoDown && !canGoUp && !canGoLeft && !canGoRight){
				break;
				}
			}
			
			// 0 is up
			// 1 is right
			// 2 is down
			// 3 is left
			int randomDirection = Random.Range(0,4);
				while(true){
					if(randomDirection == 0 && canGoUp == false){
						randomDirection = Random.Range(0,4);
					}
					else if(randomDirection == 1 && canGoRight == false){
						randomDirection = Random.Range(0,4);
					}
					else if(randomDirection == 2 && canGoDown == false){
						randomDirection = Random.Range(0,4);
					}
					else if(randomDirection == 3 && canGoLeft == false){
						randomDirection = Random.Range(0,4);
					}
					else{					
						break;
					}
				}
				if(randomDirection == 0 && canGoUp) {
					//Instantiate(roomA, new Vector2(currentXPosition, currentYPosition + 10), Quaternion.identity);
					currentYPosition += 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);
					roomExitType.Add("A");		
					if(roomExitType[randomRoomElementNumber] == "C"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "H");
						Debug.Log("Replaced C with H");
					}
					if(roomExitType[randomRoomElementNumber] == "D"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "J");
						Debug.Log("Replaced D with J");
					}
					if(roomExitType[randomRoomElementNumber] == "E"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "G");
						Debug.Log("Replaced E with G");
					}		
				}
				else if(randomDirection == 2 && canGoDown) {
					//Instantiate(roomA, new Vector2(currentXPosition, currentYPosition - 10), Quaternion.identity);
					currentYPosition -= 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);	
					roomExitType.Add("A");
					if(roomExitType[randomRoomElementNumber] == "C"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "I");
						Debug.Log("Replaced C with I");
					}
					if(roomExitType[randomRoomElementNumber] == "B"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "J");
						Debug.Log("Replaced B with J");
					}
					if(roomExitType[randomRoomElementNumber] == "F"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "G");
						Debug.Log("Replaced F with G");
					}				
				}
				else if(randomDirection == 1 && canGoRight) {
					//Instantiate(roomC, new Vector2(currentXPosition + 10, currentYPosition), Quaternion.identity);
					currentXPosition += 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);
					roomExitType.Add("C");
					if(roomExitType[randomRoomElementNumber] == "A"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "J");
						Debug.Log("Replaced A with J");
					}
					if(roomExitType[randomRoomElementNumber] == "E"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "I");
						Debug.Log("Replaced E with I");
					}
					if(roomExitType[randomRoomElementNumber] == "F"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "H");
						Debug.Log("Replaced F with H");
					}
				}
				else if(randomDirection == 3 && canGoLeft) {
					//Instantiate(roomC, new Vector2(currentXPosition - 10, currentYPosition), Quaternion.identity);
					currentXPosition -= 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);
					roomExitType.Add("C");
					if(roomExitType[randomRoomElementNumber] == "A"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "G");
						Debug.Log("Replaced A with G");
					}
					if(roomExitType[randomRoomElementNumber] == "B"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "H");
						Debug.Log("Replaced B with H");
					}
					if(roomExitType[randomRoomElementNumber] == "D"){
						roomExitType.RemoveAt(randomRoomElementNumber);
						roomExitType.Insert(randomRoomElementNumber, "I");
						Debug.Log("Replaced D with I");
					}
				}    
			}
		}
	
		private void InstantiateRooms(){
			for(int  i = 0; i< roomExitType.Count; i++){
				Debug.Log(roomExitType[i]);
				if(roomExitType[i] == "A"){
					Instantiate(roomA, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "B"){
					Instantiate(roomB, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "C"){
					Instantiate(roomC, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "D"){
					Instantiate(roomD, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "E"){
					Instantiate(roomE, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "F"){
					Instantiate(roomF, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "G"){
					Instantiate(roomG, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "H"){
					Instantiate(roomH, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "I"){
					Instantiate(roomI, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if(roomExitType[i] == "J"){
					Instantiate(roomJ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 0){
					Instantiate(roomBottomExitYZ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 1){
					Instantiate(roomLeftExitY, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
						
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 2){
					Instantiate(roomTopExitYZ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				
				}

				
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 1){
					Instantiate(roomRightExitZ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 0){
					Instantiate(roomTopExitYZ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 2){
					Instantiate(roomBottomExitYZ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
				
				}
			}
		}
}
