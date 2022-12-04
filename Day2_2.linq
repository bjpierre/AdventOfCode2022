void Main()
{
	string[] movesList = input;
	int score = 0;
	for(var i =0; i < movesList.Length; i++){
		score+=calcScore(movesList[i].Split(' ').Select(s=>s[0]).ToArray());
	}
	$"Final score was {score}!".Dump();
}

public int calcScore(char[] line)
{
	char MyMove = getMove(line);
	return moveToInt(MyMove) + outcomeToInt(line[1]);
}

//TODO BJP there is a very obvious way to do this rolling over at 4 but it's escaping me
public char getMove(char[] line){
	var move = line[0];
	switch(line[1])
	{
		case 'Z' : //Win
			return line[0] switch
			{
				'A' => 'B',
				'B' => 'C',
				'C' => 'A',
				_ => throw new ArgumentException(nameof(line))
			};
		case 'Y' : //Draw
			return line[0] switch
			{
				'A' => 'A',
				'B' => 'B',
				'C' => 'C',
				_ => throw new ArgumentException(nameof(line))
			};
		case 'X' : //Lose
			return line[0] switch
			{
				'A' => 'C',
				'B' => 'A',
				'C' => 'B',
				_ => throw new ArgumentException(nameof(line))
			};
		default:
		throw new ArgumentException(nameof(line));
	}
}

public int moveToInt(char playerMove)
{
 	return playerMove switch { 
		'A'=> 1, //Rock
		'B'=> 2, //Paper
		'C' => 3, //Scissors
		_ => throw new ArgumentException (nameof(playerMove)) 
	};
}

public int outcomeToInt(char outCome){
 	return outCome switch { 
	'X'=> 0, //Rock
	'Y'=> 3, //Paper
	'Z' => 6, //Scissors
	_ => throw new ArgumentException (nameof(outCome)) 
	};
}

string[] debugInput = @"A Y
B X
C Z".Split('\n');
string[] input = "....".Split('\n');
