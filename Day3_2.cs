void Main()
{

	var sum = 0;
	var input = realInput.Split('\n').Select(s=>s.Trim()).ToArray();
	for(int i =0; i< input.Length; i+=3){
		sum+= findCommonItem(input[i], input[i+1], input[i+2]);
	}
	sum.Dump();
}

int findCommonItemWithLinq(string ruckA, string ruckB, string ruckC)
{
	//This method is one line and uses spans and refs making it execute in half the time
	var common = ruckA.Where(s=>ruckB.Contains(s) && ruckC.Contains(s)).FirstOrDefault();
	return itemToPrioritySubOne(common)+1;
}

int findCommonItem(string ruckA, string ruckB, string ruckC)
{
	var map = new int[52];
	for(int i =0; i<ruckA.Length; i++){
		map[itemToPrioritySubOne(ruckA[i])] = 1;
	}
	
	for(int i = 0; i <ruckB.Length; i++){
		var loc = itemToPrioritySubOne(ruckB[i]);
		if(map[loc] == 1){
			map[loc] =2;
		}
	}
	
	for(int i = 0; i<ruckC.Length; i++){
	var loc = itemToPrioritySubOne(ruckC[i]);
		if(map[loc]==2){
			return loc+1;
		}
	}
	throw new Exception("End of list hit with no common answer");
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

string realInput = @"....";
