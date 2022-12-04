void Main()
{
	var input = realInput.Split('\n').Select(s=>s.Trim().Split(',').Select(d=>d.Split('-').Select(f=>int.Parse(f)).ToArray()).ToArray()).ToArray();
	input.Where(s=>IsOverlap(s)).Count().Dump();
}

public bool IsOverlap(int[][] ranges){
	//Reorganize
	if(ranges[1][0] < ranges[0][0]){
		var temp = ranges[1];
		ranges[1] = ranges[0];
		ranges[0] = temp;
	}
	
	//IF A starts or ends in B, or B is entirely contained by A
	return( (ranges[0][0] >= ranges[1][0] && ranges[0][0] <= ranges[1][1])
		|| (ranges[0][1] >= ranges[1][0] && ranges[0][1] <= ranges[1][1])
		|| ranges[0][0] <= ranges[1][0] && ranges[0][1] >=ranges[1][1]
	);
}

string debugInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

string realInput = @"....";
