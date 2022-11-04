// See https://aka.ms/new-console-template for more information
using TestLinq;

Console.WriteLine("Hello, World!");
void QueryHighScores(int exam, int score)
{
    var highScores =
        from student in Students.students
        where student.ExamScores[exam] > score
        select new
        {
            Name = student.FirstName,
            Score = student.ExamScores[exam]
        };

    foreach (var item in highScores)
    {
        Console.WriteLine($"{item.Name,-15}{item.Score}");
    }
}

QueryHighScores(1, 90);

void GetAllStudent()
{
    var Result =
        from student in Students.students
        select new
        {
            Name = student.FirstName,
            Score = student.LastName
        };

    foreach (var item in Result)
    {
        Console.WriteLine($"{item.Name,-10}{item.Score}");
    }
}
GetAllStudent();

void QueryMethod2(int[] ints, out IEnumerable<string> returnQ) =>
    returnQ =
        from i in ints
        where i % 4 == 0
        select i.ToString();

int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Query myQuery1 is executed in the following foreach loop.
QueryMethod2(nums, out IEnumerable<string> myQuery2);

// Execute the returned query.
var groupByLastNamesQuery = from st in Students.students
                            where st.ID < 116
                            group st by st.LastName into groupST
                            orderby groupST.Key
                            select groupST;

foreach (var nameGroup in groupByLastNamesQuery)
{
    Console.WriteLine($"Key: {nameGroup.Key}");
    foreach (var student in nameGroup)
    {
        Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
    }
}