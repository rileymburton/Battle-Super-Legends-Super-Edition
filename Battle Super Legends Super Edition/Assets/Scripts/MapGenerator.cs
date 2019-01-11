using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	private List <int> spawnDirections = new List<int>();
	private List <string> roomExitType = new List<string>();	

	private List <int> xPosition = new List<int>();
	private List <int> yPosition = new List<int>();
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

	


	// Use this for initialization
	void Start () {
		
		numberOfRooms = Random.Range(100,200);
		Debug.Log("Number of Rooms = " + numberOfRooms);
		GenerateMap();
		AssignRoomCode();
		PlaceRooms();
		PlaceRandomRooms();
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
		}
		
		roomExitType.Add("Y");
		foreach(string x in roomExitType){
			//Debug.Log(x);
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
					
				}
			}
		}

		private void PlaceRandomRooms(){
		for(int i = Random.Range(5, 10); i <numberOfRooms -1; i+= Random.Range(25,50)){
			bool canGoUp = true;
			bool canGoRight = true;
			bool canGoDown = true;
			bool canGoLeft = true;
			int currentXPosition = xPosition[i];
			int currentYPosition = yPosition[i];
			//Debug.Log(i);
			//Debug.Log(currentXPosition + " " + currentYPosition);
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
					BranchingRooms(currentXPosition, currentYPosition+10);		
					if(roomExitType[i] == "C"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "H");
						Debug.Log("Replaced C with H");
					}
					if(roomExitType[i] == "D"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "J");
						Debug.Log("Replaced D with J");
					}
					if(roomExitType[i] == "E"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "G");
						Debug.Log("Replaced E with G");
					}		
				}
				else if(randomDirection == 2 && canGoDown) {
					//Instantiate(roomA, new Vector2(currentXPosition, currentYPosition - 10), Quaternion.identity);
					currentYPosition -= 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);	
					roomExitType.Add("A");
					BranchingRooms(currentXPosition, currentYPosition-10);
					if(roomExitType[i] == "C"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "I");
						Debug.Log("Replaced C with I");
					}
					if(roomExitType[i] == "B"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "J");
						Debug.Log("Replaced B with J");
					}
					if(roomExitType[i] == "F"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "G");
						Debug.Log("Replaced F with G");
					}				
				}
				else if(randomDirection == 1 && canGoRight) {
					//Instantiate(roomC, new Vector2(currentXPosition + 10, currentYPosition), Quaternion.identity);
					currentXPosition += 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);
					roomExitType.Add("C");
					BranchingRooms(currentXPosition+10, currentYPosition);
					if(roomExitType[i] == "A"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "J");
						Debug.Log("Replaced A with J");
					}
					if(roomExitType[i] == "E"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "I");
						Debug.Log("Replaced E with I");
					}
					if(roomExitType[i] == "F"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "H");
						Debug.Log("Replaced F with H");
					}
				}
				else if(randomDirection == 3 && canGoLeft) {
					//Instantiate(roomC, new Vector2(currentXPosition - 10, currentYPosition), Quaternion.identity);
					currentXPosition -= 10;
					xPosition.Add(currentXPosition);
					yPosition.Add(currentYPosition);
					roomExitType.Add("C");
					BranchingRooms(currentXPosition-10, currentYPosition);
					if(roomExitType[i] == "A"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "G");
						Debug.Log("Replaced A with G");
					}
					if(roomExitType[i] == "B"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "H");
						Debug.Log("Replaced B with H");
					}
					if(roomExitType[i] == "D"){
						roomExitType.RemoveAt(i);
						roomExitType.Insert(i, "I");
						Debug.Log("Replaced D with I");
					}
				}    
			}
		}
	
		private void BranchingRooms(int xCoordinate, int yCoordinate){
			bool canGoUp = true;
			bool canGoRight = true;
			bool canGoDown = true;
			bool canGoLeft = true;
			int numberOfBranchingRooms = Random.Range(10, 15);
			List<int> BranchingRoomsDirection = new List<int>();
			for(int i = 0; i < numberOfBranchingRooms; i++){
			for(int j = 0; j < xPosition.Count; j++){
				if(xPosition[j] == xCoordinate && yPosition[j] == yCoordinate + 10){
					canGoUp = false;
				}
				if(xPosition[j] == xCoordinate + 10 && yPosition[j] == yCoordinate){
					canGoRight = false;
				}
				if(xPosition[j] == xCoordinate && yPosition[j] == yCoordinate - 10){
					canGoDown = false;
				}
				if(xPosition[j] == xCoordinate - 10 && yPosition[j] == yCoordinate){
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
			BranchingRoomsDirection.Add(randomDirection);
		}
		for(int k = 0; k < BranchingRoomsDirection.Count-1; k++){
			if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 0){
				yCoordinate+=10;
				roomExitType.Add("A");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}
			else if(BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 2){
				yCoordinate-=10;
				roomExitType.Add("A");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				

			}

			else if (BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 2) {
				yCoordinate-=10;
				roomExitType.Add("B");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}
			else if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 3){
				xCoordinate-=10;
				roomExitType.Add("B");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	

			else if(BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 1){
				xCoordinate+=10;
				roomExitType.Add("C");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
			
			}

			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 3){
				xCoordinate-=10;
				roomExitType.Add("C");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	

			else if(BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 0){
				yCoordinate+=10;
				roomExitType.Add("D");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}
			else if(BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 3){
				xCoordinate-=10;
				roomExitType.Add("D");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	
	
			else if (BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 1){
				xCoordinate+=10;
				roomExitType.Add("E");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}
			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 0){
				xCoordinate-=10;
				roomExitType.Add("E");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	

			else if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 1){
				xCoordinate+=10;
				roomExitType.Add("F");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	
			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 2){
				yCoordinate-=10;
				roomExitType.Add("F");
				xPosition.Add(xCoordinate);
				yPosition.Add(yCoordinate);
				
			}	
			
		}
	}
		private void InstantiateRooms(){
			for(int  i = 0; i< roomExitType.Count; i++){
				//Debug.Log(roomExitType[i]);
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
