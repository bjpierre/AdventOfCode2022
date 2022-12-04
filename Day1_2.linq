void Main()
{
var calsTrack = new List<int>();
	var input = 
	@"......".Split('\n');
var curSum = 0;
foreach(var cals in input){
	if(string.IsNullOrWhiteSpace(cals)){
		calsTrack.Add(curSum);
		curSum=0;
		continue;
	}
	var cur = Int32.Parse(cals);
	curSum+= cur;
}
calsTrack.OrderByDescending(s=>s).Take(3).Sum(s=>s).Dump();
}
