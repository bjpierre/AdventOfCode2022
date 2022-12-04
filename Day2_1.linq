void Main()
{
	int score = 0;
	RunTests();
	for(var i =0; i < input.Length; i++){
		score+=calcScore(input[i]);
	}
	$"Final score was {score}!".Dump();
}

public int calcScore(string line){
	var moves = line.Split(' ').Select(s=>s[0]).ToArray();
	return moveVal(moves[1]) + winVal(moves);
}

public int moveVal(char playerMove)
{
 	return playerMove switch { 
	'X' => 1, 'A'=> 1,
	'Y' => 2, 'B'=> 2,
	'Z' => 3, 'C' => 3,
	_ => throw new ArgumentException (nameof(playerMove)) };
}

public int winVal(char[] moves){
	var playerMove = moveVal(moves[1]);
	var opponentMove = moveVal(moves[0]);
	//TODO there is definitely a better way of doing this
	if((playerMove>opponentMove || (playerMove==1 && opponentMove==3))&&!(opponentMove==1&&playerMove==3)) return 6;
	if(opponentMove.Equals(playerMove)) return 3;
	return 0;
}


public void RunTests(){
	$"{moveVal('X')} == {moveVal('A') == 1}".Dump();
	$"{moveVal('Y')} == {moveVal('B') == 2}".Dump();
	$"{moveVal('Z')} == {moveVal('C') == 3}".Dump();
	$"{winVal(new char[]{'X','Z'})} == {3}".Dump();
	$"{winVal(new char[]{'Y','Z'})} == {0}".Dump();
	$"{winVal(new char[]{'X','B'})} == {6}".Dump();
	$"{winVal(new char[]{'X','C'})} == {0}".Dump();
	$"{winVal(new char[]{'Z','A'})} == {6}".Dump();
}

//A=X=1=Rock, B=Y=2=Paper, C=Z=3=Scissors
//0 For L, 3 for Draw, 6 for Win

string[] debugInput = @"A Y
B X
C Z".Split('\n');
string[] input = 
@"...".Split('\n');
