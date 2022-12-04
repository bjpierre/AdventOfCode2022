void Main()
{

	var sum = 0;
	var input = realInput.Split('\n').Select(s=>s.Trim()).ToArray();
	for(int i =0; i< input.Length; i++){
		sum+= findSumOfRuckSack(input[i]);
	}
	sum.Dump();
}

int findSumOfRuckSack(string rucksack){
	if(rucksack.Length%2!=0) throw new ArgumentException($"{nameof(rucksack)} has an odd length");
	var iter = 0;
	var localSum = 0;
	var map = new bool[52];
	while(iter < rucksack.Length/2)
	{
		var loc = itemToPrioritySubOne(rucksack[iter++]);
		map[loc] = true;
	}
	while(iter<rucksack.Length){
		var loc = itemToPrioritySubOne(rucksack[iter++]);
		if(map[loc] ==true){
			localSum+=1+loc;
			map[loc]=false; //No duplicates
		}
	}
	return localSum;
}

public int itemToPrioritySubOne(char c)
{
	var asInt = (int)c;
	return asInt < 97 ? (asInt - 65 + 26) : asInt - 97;
}

string debugInput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

string realInput = @"......";
