using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;





namespace Call_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<member> memberList = ReadMembers();
            {
                var member = new Member();
                string MemberName;
                int CallLength;
                string Resolved;
                string userInput;
                int memberId;




                do
                {
                    Console.WriteLine("Do you need to document a new call? Please type 'yes' or 'no'. ");
                    userInput = Console.ReadLine();
                    {
                        case "no";
                        new Member();
                        break;
                    }

                    if (userInput != "no") ;
                    {
                        Console.WriteLine("Please enter the first name of your caller.");
                        member.MemberName = Console.ReadLine();
                        Console.WriteLine("Please enter the member ID for your member.");
                        member.memberId = Console.ReadLine();
                        Console.WriteLine("Please enter the lenght of your call");
                        member.CallLength = Console.ReadLine();
                        Console.WriteLine("Was the issue resolved?");
                        member.Resolved = Console.ReadLine();

                    }
                    else

                    {
                        int counter = 1;
                        foreach Member member in memberList)
                        {
                            Console.WriteLine(counter.ToString() + ", " + MemberName + " " + .memberId + " " + CallLength + " call resolved: " + Resolved + " .");

                        }

                        DateTime today = DateTime.Today;
                        int daysUntilFriday = ((int)DayOfWeek.Friday - (int)today.DayOfWeek + 7) % 7);
                        DateTime nextFriday = today.AddDays(daysUntilFriday);


                        Console.WriteLine("Which member would you like to view?");
                        var v = Convert.ToInt32((Console.ReadLine()));
                        Console.WriteLine("If this member's inquiry is not resolved please call them back by Friday. Which is in " + daysUntilFriday + " days.");



                    }






                } while (userInput != "exit");

                WriteMembers(memberList);







            }










        }
        public static void WriteMembers(List<Member> members)
        {
            using (var writer = new StreamWriter("MemberList.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(members);
            }
            public static List<Member> ReadMembers()
            {

                var CSVConfig = new CsvConfiguration(CultureInfo.CurrentCultuer);
                using var StreamReader = File.OpenText("MemberList.csv");
                using var csvReader = new CsvReader(CsvReader, CSVConfig);
                string GetData;
                var isLineOne = true;
                List<Member> memberList -new List<Member>();


                while (csvReader.Read())
                {
                    if (isLineOne == true)
                    {

                        isLineOne = false;
                    }
                    else
                    {
                        Member member = new Member();
                        string Name;
                        int MemberId;
                        string Resolved;
                        csvReader.TryGetField<string>(0, out Name);
                        csvReader.TryGetField<int>(1, out MemberId);
                        csvReader.TryGetField<string>(2, out Resolved);
                        member.MemberName = Name;
                        member.memberId = MemberId;
                        member.Resolved = Resolved;

                        memberList.Add(member);

                    }



                }
                StreamReader.Close();
                csvReader.Dispose();
                return toonList;


            }
        }






    }














}
