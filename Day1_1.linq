void Main()
{
  var max = 0;
	var input = 
	@"......".Split('\n');
var curSum = 0;
foreach(var cals in input){
	if(string.IsNullOrWhiteSpace(cals)){
		if(curSum>max) max = curSum;
		curSum=0;
		continue;
	}
	var cur = Int32.Parse(cals);
	curSum+= cur;
}
curSum.Dump();
}
