using System.Collections;

//University university = new University();
//foreach (Student item in university)
//{
//    Console.WriteLine(item);
//    Console.WriteLine();
//}

//Console.WriteLine("*************************");


//university.Sort();
//foreach (Student item in university)
//{
//    Console.WriteLine(item);
//    Console.WriteLine();
//}

//university.Sort(new LastNameComparer());
//university.Sort(new BirthDateComparer());

Student student1 = new Student
{
    FirstName = "Hello",
    LastName = "Goodbuy",
    BirthDay = new DateTime(2000, 11,25),
    studentCard = new StudentCard
    {
        Series = "AAA",
        Number = 11111,
        EndOfWork = new DateTime(2027, 11,06)
    }
};

Console.WriteLine(student1);

Student st2 = student1 as Student;
Console.WriteLine(st2);
student1.FirstName = "Ivan";
Console.WriteLine(student1);
class StudentCard
{
    public string Series { get; set; }
    public int Number { get; set; }
    public DateTime EndOfWork { get; set; }
    public override string ToString()
    {
        return $"{Series}-{Number}\n" +
            $"End of work {EndOfWork.ToShortDateString()}";
    }
}
    class Student: IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public StudentCard studentCard { get; set; }

    public object Clone()
    {
        Student student = (Student)this.MemberwiseClone();
        student.studentCard = new StudentCard
        {
            Number = this.studentCard.Number,
            Series = this.studentCard.Series,
            EndOfWork = this.studentCard.EndOfWork
        };
        return student;
    }

    public int CompareTo(Student? other)
    {
        return this.FirstName.CompareTo(other.FirstName);
    }

    public override string ToString()
    {
        return $"Name : {FirstName}\nSurname : {LastName}\nBirthday : {BirthDay.ToShortDateString()}\n" +
            $"{studentCard.ToString()}";
    }
}
class University: IEnumerable
{
    Student[] students =
    {
        new Student
        {
            FirstName = "Ivanov",
            LastName = "Ivan",
            BirthDay = new DateTime(2000, 12,31),
            studentCard = new StudentCard
            {
                Number = 10000001,
                Series = "AAA",
                EndOfWork = new DateTime(2025, 06, 29)
            }
        },
        new Student
        {
            FirstName = "Petrov",
            LastName = "Petro",
            BirthDay = new DateTime(2002, 11,30),
            studentCard = new StudentCard
            {
                Number = 10000023,
                Series = "AAB",
                EndOfWork = new DateTime(2026, 06, 30)
            }
        },
        new Student
        {
            FirstName = "Pavlov",
            LastName = "Pavlo",
            BirthDay = new DateTime(1999, 11,29),
            studentCard = new StudentCard
            {
                Number = 1000023431,
                Series = "DFC",
                EndOfWork = new DateTime(2027, 06, 21)
            }
        },
        new Student
        {
            FirstName = "Qwerty",
            LastName = "Qwert",
            BirthDay = new DateTime(2004, 10,28),
            studentCard = new StudentCard
            {
                Number = 103424001,
                Series = "AAC",
                EndOfWork = new DateTime(2027, 06, 25)
            }
        },
        new Student
        {
            FirstName = "Maksimneko",
            LastName = "Maxim",
            BirthDay = new DateTime(2002, 10,25),
            studentCard = new StudentCard
            {
                Number = 10000001,
                Series = "AAA",
                EndOfWork = new DateTime(2025, 06, 29)
            }
        }
    };
    public void Sort()
    {
        Array.Sort(students);
    }
    public void Sort(IComparer<Student> comparer)
    {
        Array.Sort(students, comparer);
    }

    public IEnumerator GetEnumerator()
    {
        return students.GetEnumerator();
    }
}
class LastNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x is Student && y is Student)
        {
            return x.LastName.CompareTo(y.LastName);
        }
        throw new Exception("Invalid LastName");
    }
}
class BirthDateComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x is Student && y is Student)
        {
            return x.BirthDay.CompareTo(y.BirthDay);
        }
        throw new Exception("Invalid Birth Day");
    }
}