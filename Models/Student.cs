public class Student
{
    public int stud_id { get; set; }
    public string stud_name { get; set; } = ""; // Provide a default value

    // Rest of the properties remain unchanged
    public string stud_course { get; set; }
    public List<string> Subject { get; set; }

    public Student()
    {
        // Optionally, provide a default value for other properties as well
        stud_course = "";
        Subject = new List<string>();
    }
}