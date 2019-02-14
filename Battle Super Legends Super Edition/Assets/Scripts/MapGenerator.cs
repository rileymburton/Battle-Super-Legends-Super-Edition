using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	private List <int> spawnDirections = new List<int>();
	private List <string> roomExitType = new List<string>();	

	private List <int> xPosition = new List<int>();
	private List <int> yPosition = new List<int>();
	public GameObject roomA;
	public GameObject roomA1;
	public GameObject roomA2;


	public GameObject roomB;
	public GameObject roomB1;
	public GameObject roomB2;
	public GameObject roomC;
	public GameObject roomC1;
	public GameObject roomC2;
	public GameObject roomD;
	public GameObject roomD1;
	public GameObject roomD2;

	public GameObject roomE;
	public GameObject roomE1;
	public GameObject roomE2;
	public GameObject roomF;
	public GameObject roomF1;
	public GameObject roomF2;

	public GameObject roomG;
	public GameObject roomG1;
	public GameObject roomG2;
	public GameObject roomH;
	public GameObject roomH1;
	public GameObject roomH2;
	public GameObject roomI;
	public GameObject roomI1;
	public GameObject roomI2;
	public GameObject roomJ;
	public GameObject roomJ1;
	public GameObject roomJ2;

	public GameObject roomXLeft;
	public GameObject roomXLeft1;
	public GameObject roomXLeft2;

	public GameObject roomXRight;
	public GameObject roomXRight1;
	public GameObject roomXRight2;

	public GameObject roomXBottom;
	public GameObject roomXBottom1;
	public GameObject roomXBottom2;

	public GameObject roomXTop;
	public GameObject roomXTop1;
	public GameObject roomXTop2;

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
	}
	private void PlaceRooms(){
		int xDisplacement = 0;
		int yDisplacement = 0;
			for(int i=0; i < numberOfRooms; i++){
				if(roomExitType[i] == "A"){
				xPosition.Add(xDisplacement);
				yPosition.Add(yDisplacement);
					if(spawnDirections[i] == 0){
						yDisplacement += 10;
					} else {
						yDisplacement -= 10;
					}
				}
				else if(roomExitType[i] == "B"){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);
					xDisplacement += 10;
				}
				else if(roomExitType[i] == "C"){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);					
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "D"){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "E"){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else if (roomExitType[i] == "F"){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement+= 10;
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 0){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 1){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Y" && spawnDirections[i] == 2){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 1){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					xDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 0){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement += 10;
				}
				else if (roomExitType[i] == "Z" && spawnDirections[i+1] == 2){
					xPosition.Add(xDisplacement);
					yPosition.Add(yDisplacement);	
					yDisplacement -= 10;
				}
				else {
					
				}
			}
		}

		private void PlaceRandomRooms(){
		for(int i = Random.Range(5, 10); i <numberOfRooms -1; i+= Random.Range(10,25)){
			bool canGoUp = true;
			bool canGoRight = true;
			bool canGoDown = true;
			bool canGoLeft = true;
			int currentXPosition = xPosition[i];
			int currentYPosition = yPosition[i];
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
					currentYPosition += 10;
					BranchingRooms(currentXPosition, currentYPosition, 0);		
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
					currentYPosition -= 10;
					BranchingRooms(currentXPosition, currentYPosition, 2);
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
					currentXPosition += 10;
					BranchingRooms(currentXPosition, currentYPosition, 1);
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
					currentXPosition -= 10;
					BranchingRooms(currentXPosition, currentYPosition, 3);
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
 		private void BranchingRooms(int xCoordinate, int yCoordinate, int prevDirection){
			bool canGoUp = true;
			bool canGoRight = true;
			bool canGoDown = true;
			bool canGoLeft = true;
			int numberOfBranchingRooms = Random.Range(20, 30);
			List<int> BranchingRoomsDirection = new List<int>();
			BranchingRoomsDirection.Add(prevDirection);
			int randomDirection;
			for(int i = 0; i< numberOfBranchingRooms; i++){
				canGoUp = true;
				canGoRight = true;
				canGoDown = true;
			    canGoLeft = true;
				for(int x = 0; x< xPosition.Count; x++){
				
					if(xPosition[x] == xCoordinate && yPosition[x] == yCoordinate + 10){
						canGoUp = false;
					}
					if(xPosition[x] == xCoordinate + 10 && yPosition[x] == yCoordinate){
						canGoRight = false;
					}
					if(xPosition[x] == xCoordinate && yPosition[x] == yCoordinate - 10){
						canGoDown = false;
					}
					if(xPosition[x] == xCoordinate - 10 && yPosition[x] == yCoordinate){
						canGoLeft = false;
					}
				}
				if(!canGoDown && !canGoUp && !canGoLeft && !canGoRight){
					numberOfBranchingRooms = i;
					continue;
				}
			
			while(true){
				randomDirection = Random.Range(0,4);
				if(randomDirection == 0 && prevDirection != 2 && canGoUp){
					BranchingRoomsDirection.Add(randomDirection);
					prevDirection = randomDirection;
					xPosition.Add(xCoordinate);
					yPosition.Add(yCoordinate);
					yCoordinate +=10;
					break;
				}
				else if(randomDirection == 1 && prevDirection != 3 && canGoRight){
					BranchingRoomsDirection.Add(randomDirection);
					prevDirection = randomDirection;
					xPosition.Add(xCoordinate);
					yPosition.Add(yCoordinate);
					xCoordinate +=10;
					break;
				}
				else if(randomDirection == 2 && prevDirection != 0 && canGoDown){
					BranchingRoomsDirection.Add(randomDirection);
					prevDirection = randomDirection;
					xPosition.Add(xCoordinate);
					yPosition.Add(yCoordinate);
					yCoordinate -=10;
					break;
				}
				else if(randomDirection == 3 && prevDirection != 1 && canGoLeft){
					BranchingRoomsDirection.Add(randomDirection);
					prevDirection = randomDirection;
					xPosition.Add(xCoordinate);
					yPosition.Add(yCoordinate);
					xCoordinate -=10;
					break;
				}
			}
		 }
		for(int k = 0; k < numberOfBranchingRooms; k++){
			if(k == numberOfBranchingRooms-1){
				if(BranchingRoomsDirection[k] == 0){
					roomExitType.Add("XBottomExit");
				}
				else if (BranchingRoomsDirection[k] == 1){
					roomExitType.Add("XLeftExit");
				}
				else if (BranchingRoomsDirection[k] == 2){
					roomExitType.Add("XTopExit");
				}
				else if (BranchingRoomsDirection[k] == 3){
					roomExitType.Add("XRightExit");
				}
			}
			else if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 0){
				roomExitType.Add("A");
			}
			else if(BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 2){
				roomExitType.Add("A");
			}

			else if (BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 2) {
				roomExitType.Add("B");
			}
			else if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 3){
				roomExitType.Add("B");
			}	

			else if(BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 1){
				roomExitType.Add("C");
			}

			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 3){
				roomExitType.Add("C");
			}	

			else if(BranchingRoomsDirection[k+1] == 1 && BranchingRoomsDirection[k] == 0){
				roomExitType.Add("D");
			}
			else if(BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 3){
				roomExitType.Add("D");
			}	
	
			else if (BranchingRoomsDirection[k+1] == 2 && BranchingRoomsDirection[k] == 1){
				roomExitType.Add("E");
			}
			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 0){
				roomExitType.Add("E");
			}	

			else if(BranchingRoomsDirection[k+1] == 0 && BranchingRoomsDirection[k] == 1){
				roomExitType.Add("F");
			}	
			else if(BranchingRoomsDirection[k+1] == 3 && BranchingRoomsDirection[k] == 2){
				roomExitType.Add("F");
			}	
		}
	}
		private void InstantiateRooms(){
			for(int  i = 0; i< roomExitType.Count; i++){
				int randomChoice;
				if(roomExitType[i] == "A"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomA, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomA1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomA2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "B"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomB, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomB1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomB2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "C"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomC, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomC1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomC2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "D"){
				    randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomD, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomD1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomD2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "E"){
					randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomE, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomE1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomE2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "F"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomF, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomF1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomF2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "G"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomG, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomG1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomG2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "H"){
					randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomH, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomH1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomH2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "I"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomI, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomI1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomI2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "J"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomJ, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomJ1, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomJ2, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "XTopExit"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomXTop, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomXTop, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomXTop, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "XBottomExit"){
				 		randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomXBottom, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomXBottom, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomXBottom, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "XRightExit"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomXRight, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomXRight, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomXRight, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
				}
				else if(roomExitType[i] == "XLeftExit"){
				 	randomChoice = Random.Range(0,2);
					if(randomChoice == 0){
						Instantiate(roomXLeft, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 1){
						Instantiate(roomXLeft, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
					else if(randomChoice == 2){
						Instantiate(roomXLeft, new Vector2(xPosition[i], yPosition[i]), Quaternion.identity);
					}
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
	
