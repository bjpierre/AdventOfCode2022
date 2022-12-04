void Main()
{
	var input = realInput.Split('\n').Select(s=>s.Trim().Split(',').Select(d=>d.Split('-')).ToArray());
	var overlaps = input.Where(s=>
		(int.Parse(s[0][0]) <= int.Parse(s[1][0]) && int.Parse(s[0][1]) >= int.Parse(s[1][1])) //A contains B
		|| (int.Parse(s[1][0]) <= int.Parse(s[0][0]) && int.Parse(s[1][1]) >= int.Parse(s[0][1])) //B contains A
	);
	overlaps.Count().Dump();
}

string debugInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

string realInput = @"......";
